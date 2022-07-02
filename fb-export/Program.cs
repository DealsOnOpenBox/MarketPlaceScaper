

using System.Diagnostics;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shared_library.Contexts;
using shared_library.Helpers;

var services = new ServiceCollection();

services.AddDbContext<MainContext>(
options =>
{
    options.UseSqlServer(Settings.sql_connection_string);
});

var provider = services.BuildServiceProvider();


var db = provider.GetService<MainContext>();


using(var book=new XLWorkbook())
{
    var sheet = book.AddWorksheet("Default");
    int row = 1, col = 1;
    var query = db
        .scraped_database
        .Select(s => new
        {
            s.id,
            s.name,
            s.user_join,
            s.date,
            s.rating_count,
            s.avg_rating,
            locations = s.locations
            .Select(l => new
            {
                l.city,
                l.state,
                l.category,

            })
        }).ToList();

    sheet.Cell(row, col++).Value = "Id";
    sheet.Cell(row, col++).Value = "Name";
    sheet.Cell(row, col++).Value = "Profile";
    sheet.Cell(row, col++).Value = "Avg Rating";
    sheet.Cell(row, col++).Value = "Rating Count";
    sheet.Cell(row, col++).Value = "Member Since";
    sheet.Cell(row, col++).Value = "City";
    sheet.Cell(row, col++).Value = "State";
    sheet.Cell(row, col++).Value = "Categories";

    

    foreach(var item in query.OrderByDescending(s=>s.date))
    {

        row++;col = 1;
        sheet.Cell(row, col++).Value = item.id;
        sheet.Cell(row, col++).Value = item.name;
        sheet.Cell(row, col).Value = "Open";
        sheet.Cell(row, col++).Hyperlink = new XLHyperlink("https://facebook.com/" + item.id);
        sheet.Cell(row, col++).Value = item.avg_rating;
        sheet.Cell(row, col++).Value = item.rating_count;
        sheet.Cell(row, col++).Value = item.user_join;

        var cities = item.locations
            .Select(s => s.city)
            .Distinct();
        var states = item
            .locations
            .Select(s => s.state)
            .Distinct();
        var categories = item
            .locations
            .Select(s => s.category)
            .Distinct();


        sheet.Cell(row, col++).Value = string.Join(",", item.locations
            .Select(s => s.city)
            .Distinct());
        sheet.Cell(row, col++).Value = string.Join(",", item
            .locations
            .Select(s => s.state)
            .Distinct());
        sheet.Cell(row, col++).Value = string.Join(",", item
            .locations
            .Select(s => s.category)
            .Distinct());

    }
    var fileName = $"Export {DateTime.Today.ToLongDateString()}.xlsx";
    book.SaveAs(fileName);
    //Process.Start(fileName);

}