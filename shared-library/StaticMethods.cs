using System;
using Newtonsoft.Json;
using PuppeteerSharp;
//marketplace_user_profile
namespace shared_library
{
	static public class StaticMethods
	{
		static Browser browser;
		static private string cookiesText="datr=7h-eYmN3izJT-FWUGoF8WH6a; sb=OyOeYo74KMwcwoJrmYQ6NjNc; wd=1200x637; dpr=2; c_user=100072277298651; xs=11:gVz988rQC4U5wQ:2:1654530891:-1:-1; fr=0chva1jIeu29woKAn.AWUS861LkREh1iTM4KTdnTG335A.BiniM7.CE.AAA.0.0.BiniNN.AWWz5hqnXu0; presence=C{\"t3\":[],\"utc3\":1654530897544,\"v\":1}";

		static public async Task<Browser> launchBrowser()
		{
			Console.WriteLine("Checking Browser");
			using var browserFetcher = new BrowserFetcher();
			Console.WriteLine("Downloading Browser...");
			await browserFetcher.DownloadAsync();
			Console.WriteLine("Launching Browser...");

			browser = await Puppeteer.LaunchAsync(
				new LaunchOptions { Headless = false });
			return browser;

		}


		static public async Task<Page> setCookies()
		{
			Console.WriteLine("Trying to login ...");
			var page = await browser.NewPageAsync();
			await page.GoToAsync("https://www.facebook.com");
			var cookiesParams = cookiesText
				.Split("; ")
				.Select(s => new CookieParam()
				{
					Name = s.Split("=")[0],
					Value = s.Split("=")[1]
				}).ToArray();

			await page.SetCookieAsync(cookiesParams);
			await page.ReloadAsync();
			Console.WriteLine("Opening marketplace ...");
			await page.GoToAsync("https://www.facebook.com/marketplace");
			return page;

		}

		static public async Task setLocation(Page page)
		{
			var zipData = await getLocation();
			var script = StaticDatas.getLocationScript(zipData);
			await page.EvaluateFunctionAsync(script);
			StaticDatas.zipData = zipData;
		}

		static public async Task scrollToBottom(Page page)
		{
			await page.EvaluateFunctionAsync("()=>window.scrollBy(0, window.document.body.scrollHeight)");
		}

		static public async Task dispose()
			=> await browser.DisposeAsync();


		static public async Task<ZipcodeData> getLocation()
		{
			
			while (true)
			{
				Console.Write("Enter Location Zipcode :");
				var zipcode = Console.ReadLine();

				var client = new HttpClient();
				var content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("zipcode", zipcode),

				});

				try
				{
					var resp = await client.PostAsync("https://api-main.dealsonopenbox.com/state", content);
					var jsonData = JsonConvert.DeserializeObject<Response>(await resp.Content.ReadAsStringAsync());
					return (jsonData.data);
				}
				catch(Exception e)
				{
					Console.WriteLine("Sorry Something Went Wrong ! "+e.Message);
				}


			}
			

		}

		public class Response
		{
			public ZipcodeData data { get; set; }
		}

		public class ZipcodeData
		{
			public float latitude { get; set; }
			public float longitude { get; set; }
            public string state { get; set; }
			public int zipcode { get; set; }
			public string city { get; set; }
		}




	}
}

