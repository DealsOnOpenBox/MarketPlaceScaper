using System;
using Microsoft.Extensions.Hosting;

namespace shared_library.Services
{
	public class BrowserJob: BackgroundService
	{
		public BrowserJob()
		{
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await StaticMethods.launchBrowser();
            var page = await StaticMethods.setCookies();
            await ListnerMethod.listenResponse(page);
            while (!stoppingToken.IsCancellationRequested)
            {
				foreach (var category in StaticDatas.fbCategories)
				{
					var categoryUrl = "https://facebook.com/marketplace/category/" + category.Value;
					await page.GoToAsync(categoryUrl);
					while (true)
					{
						await Task.Delay(Random.Shared.Next(1000, 2000));
						await StaticMethods.scrollToBottom(page);
					}
					Console.ReadLine();
				}


			}

		}

    }
}

