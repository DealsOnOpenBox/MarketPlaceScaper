using System;
using System.Threading;
using Leaf.xNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PuppeteerSharp;
using shared_library.Clients;
using shared_library.Contexts;
using shared_library.Servers;

namespace shared_library
{
	static public class ListnerMethod
	{
		static public Task listenResponse(Page page)
		{
			//await page.SetRequestInterceptionAsync(true);
			page.Response += Page_Response;
			page.Close += (s, e) => page.Response -= Page_Response;
            return Task.CompletedTask;
		}


		private static async void Page_Response(object? sender, ResponseCreatedEventArgs e)
		{
			try
			{
				if (e.Response.Request.ResourceType != ResourceType.Xhr||!e.Response.Url.Contains("https://www.facebook.com/api/graphql"))
					return;
				var rawText = await e.Response.TextAsync();
                StaticDatas.lastFetched = DateTime.Now;
                await ParsingMethod.process(rawText);
				
			}
			catch(Exception ex)
			{
				StaticDatas.error++;
				Console.WriteLine("Ex -> " + ex.Message);
			}


		}



        //static public async Task listenRequest(Page page)
        //{
        //    ManualResetEvent manual = new ManualResetEvent(false);
        //    await page.SetRequestInterceptionAsync(true);

        //    Console.WriteLine("Waiting For Form Data...");

        //    EventHandler<RequestEventArgs> handler = null;

        //    var notConsiderList = new[] { "fb_api_req_friendly_name", "variables" };

        //    handler= async (s, e) => {
        //        await e.Request.ContinueAsync();
        //        if (e.Request.PostData != null & e.Request.Url.Contains("https://www.facebook.com/api/graphql"))
        //        {
        //            var body = e.Request.PostData.ToString();
        //            var keyPair = body
        //            .Split("&")
        //            .ToDictionary(s => s.Split("=").FirstOrDefault(), s => s.Split("=").LastOrDefault());

        //            Console.WriteLine("Fetched The Form Data...");

        //            StaticDatas.headers = keyPair;
        //            page.Request -= handler;
        //            await page.SetRequestInterceptionAsync(false);
        //            manual.Set();
        //        }

        //    };

        //    page.Request += handler;

        //    await page.GoToAsync("https://www.facebook.com/marketplace");
        //    manual.WaitOne();
        //    _page = page;
        //}



        //static async Task insertUsers(Dictionary<string,string> usersList)
        //{
        //    var newUserIds = usersList.Select(c => c.Key);
        //    var context = StaticDatas.provider.GetService<MainContext>();
        //    var alreadyInsertedUsers = context
        //       .scrapedUsers
        //       .Select(s => s.id)
        //       .Where(s => newUserIds.Contains(s))
        //       .ToList();

        //    var toInsertUsers = usersList
        //        .Where(s => !alreadyInsertedUsers.Contains(s.Key))
        //        .ToList();

        //    foreach (var user in toInsertUsers)
        //        context.scrapedUsers.Add(new ScrapedUser()
        //        {
        //            id = user.Key,
        //            name = user.Value,
        //            date_added = DateTime.UtcNow
        //        });
        //    await context.SaveChangesAsync();
        //    Console.WriteLine("Inserted Records : " + usersList.Count);

        //}

        //static async Task insertUsers(List<ParseUserData> parseUserDatas)
        //{
        //    var newUserIds = parseUserDatas.Select(c => c.data.user.id);
        //    lock (StaticDatas.mainContext)
        //    {
        //        var alreadyInsertedUsers = StaticDatas.mainContext
        //        .scrapedUsers
        //        .Select(s => s.id)
        //        .Where(s => newUserIds.Contains(s))
        //        .ToList();

        //        var toInsertUsers = parseUserDatas
        //            .Where(s => !alreadyInsertedUsers.Contains(s.data.user.id))
        //            .ToList();

        //        foreach (var user in toInsertUsers)
        //            StaticDatas.mainContext.scrapedUsers.Add(parseUser(user.data.user));


        //    }
        //    await StaticDatas.mainContext.SaveChangesAsync();

        //}


        //static private ScrapedUser parseUser(ParseUserData.User data)
        //{
        //    var user = new ScrapedUser();
        //    user.id = data.id;
        //    user.name = data.name;
        //    user.date_added = DateTime.UtcNow;

        //    #region contact-parse
        //    var merchant = data.commerce_merchant_settings.customer_service_information;
        //    var address = merchant.address;
        //    user.contact_info.business_type = merchant.business_type;
        //    user.contact_info.email = merchant.email;
        //    user.contact_info.phone_number = merchant.phone_number?.ToString();
        //    user.contact_info.address.city = address.city;
        //    user.contact_info.address.state = address.state;
        //    user.contact_info.address.postal_code = address.postal_code;
        //    user.contact_info.address.street_1 = address.street_1;
        //    user.contact_info.address.street_2 = address.street_2;
        //    #endregion


        //    #region market-place-parse
        //    var stats = data.marketplace_ratings_stats_by_role;
        //    user.marketlace.marketplace_id = data.commerce_merchant_settings.id;
        //    user.marketlace.five_star_ratings_average = (float)stats.seller_stats.five_star_ratings_average;
        //    user.marketlace.five_star_total_rating_count_by_role = (float)stats.seller_stats.five_star_total_rating_count_by_role;
        //    #endregion
        //    return user;

        //}

    }
}

