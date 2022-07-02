using System.Diagnostics;
using System.IO;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using shared_library.Contexts;
using web_application.Models;

namespace web_application.Controllers;

public class HomeController : Controller
{
    private readonly MainContext context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MainContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        var model = new DownloadModel();
        model.City = context
            .scraped_location
            .Select(s=>s.city)
            .Distinct()
            .ToList();
        model.State= context
            .scraped_location
            .Select(s => s.state)
            .Distinct()
            .ToList();
        model.Category= context
            .scraped_location
            .Select(s => s.category)
            .Distinct()
            .ToList();
        return View(model);
    }
    [HttpPost("Export")]
    public async Task<IActionResult> Export(string city,string state,string category)
    {
        var masterQuery = context
            .scraped_location
            .AsQueryable();
        if (!string.IsNullOrEmpty(city))
            masterQuery = masterQuery
                .Where(s => s.city == city);

        if (!string.IsNullOrEmpty(state))
            masterQuery = masterQuery
                .Where(s => s.state == state);

        if (!string.IsNullOrEmpty(category))
            masterQuery = masterQuery
                .Where(s => s.category == category);


        using (var book = new XLWorkbook())
        {
            var sheet = book.AddWorksheet("Default");
            int row = 1, col = 1;
            var query = context
                .scraped_database
                .Select(s => new
                {
                    s.id,
                    s.name,
                    s.user_join,
                    s.date,
                    s.rating_count,
                    s.avg_rating,
                }).Where(s=>masterQuery.Select(c=>c.user).Contains(s.id));

            

                sheet.Cell(row, col++).Value = "Id";
            sheet.Cell(row, col++).Value = "Name";
            sheet.Cell(row, col++).Value = "Profile";
            sheet.Cell(row, col++).Value = "Avg Rating";
            sheet.Cell(row, col++).Value = "Rating Count";
            sheet.Cell(row, col++).Value = "Member Since";



            foreach (var item in query.OrderByDescending(s => s.date))
            {

                row++; col = 1;
                sheet.Cell(row, col++).Value = item.id;
                sheet.Cell(row, col++).Value = item.name;
                sheet.Cell(row, col).Value = "Open";
                sheet.Cell(row, col++).Hyperlink = new XLHyperlink("https://facebook.com/" + item.id);
                sheet.Cell(row, col++).Value = item.avg_rating;
                sheet.Cell(row, col++).Value = item.rating_count;
                sheet.Cell(row, col++).Value = item.user_join;

                //var cities = item.locations
                //    .Select(s => s.city)
                //    .Distinct();
                //var states = item
                //    .locations
                //    .Select(s => s.state)
                //    .Distinct();
                //var categories = item
                //    .locations
                //    .Select(s => s.category)
                //    .Distinct();


                //sheet.Cell(row, col++).Value = string.Join(",", item.locations
                //    .Select(s => s.city)
                //    .Distinct());
                //sheet.Cell(row, col++).Value = string.Join(",", item
                //    .locations
                //    .Select(s => s.state)
                //    .Distinct());
                //sheet.Cell(row, col++).Value = string.Join(",", item
                //    .locations
                //    .Select(s => s.category)
                //    .Distinct());

            }
            var fileName = $"Export {DateTime.Today.ToLongDateString()}.xlsx";

            //Process.Start(fileName);
            var ms = new MemoryStream();
            book.SaveAs(ms);
            ms.Seek(0,SeekOrigin.Begin);
            return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Export_{city}_{state}_{category}_{DateTime.Today.ToLongDateString()}.xlsx");
        }
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

