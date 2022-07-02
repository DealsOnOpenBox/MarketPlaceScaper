using System;
using Leaf.xNet;
using Newtonsoft.Json;
using PuppeteerSharp;
using shared_library.Clients;

namespace shared_library
{
	static public class ParsingMethod
	{
		static public async Task process(string rawText)
		{
			if (!rawText.Contains("marketplace_search"))
				return;

			var data = JsonConvert.DeserializeObject<MarketPlaceResult>(rawText);

			var nodes = data.getNodes();
			foreach(var node in nodes)
            {
				var user = node.listing.marketplace_listing_seller;
				if (!SqlDataMethods.insertUser(node.listing.marketplace_listing_seller.id, node.listing.marketplace_listing_seller.name))
				{
					var resp = await StaticDatas.page.EvaluateFunctionAsync<string>(StaticDatas.getItemById, node.listing.id, node.tracking);
					var json = JsonConvert.DeserializeObject<MarketPlaceItem>(resp);
					SqlDataMethods.updateRating(json.data.viewer.marketplace_product_details_page.target.marketplace_listing_seller); 
					Console.WriteLine($"Inserted User {user.name}");
				}
				
					
				if(SqlDataMethods.updateCategory(node.listing.location.reverse_geocode, node.listing.marketplace_listing_seller.id))
					Console.WriteLine($"Updated User {user.name}");

			}

			if (!rawText.Contains("has_next_page\":true") || nodes.Count() == 0)
				StaticDatas.keepFetching = false;
			

			StaticDatas.pageCount++;

		}



		
	}
}

