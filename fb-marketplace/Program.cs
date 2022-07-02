
using shared_library;


await StaticMethods.launchBrowser();
var page = await StaticMethods.setCookies();
StaticDatas.page = page;
await ListnerMethod.listenResponse(page);

Console.Write("Set The Location and Radius Manually! Once Done Press Enter");
Console.ReadLine();

foreach (var category in StaticDatas.fbCategories)
{
	StaticDatas.category = category.Value;
	var categoryUrl = "https://facebook.com/marketplace/category/" + category.Value+ "?deliveryMethod=local_pick_up&exact=true";
	await page.GoToAsync(categoryUrl);
	StaticDatas.lastFetched = DateTime.Now;
	var pageContent = await page.GetContentAsync();
	if(!pageContent.Contains("Results from outside your search"))
	while (StaticDatas.keepFetching)
	{
			if (StaticDatas.lastFetched.HasValue)
				if (StaticDatas.lastFetched.Value.AddMinutes(1.5) < DateTime.Now)
					break;
		await Task.Delay(Random.Shared.Next(3000, 5000));
		await StaticMethods.scrollToBottom(page);
	}
	StaticDatas.keepFetching = true;
}


await StaticMethods.dispose();
Console.WriteLine("Scraping Completed\nPress Any Key ....");
Console.ReadLine();
