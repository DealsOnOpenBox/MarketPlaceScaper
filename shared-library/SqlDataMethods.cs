using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using shared_library.Clients;
using shared_library.Helpers;

namespace shared_library
{
	static public class SqlDataMethods
	{

		//static public async Task insert(List<MarketPlaceResultListing> listings)
  //      {
		//	using(var db= getConnection())
  //          {
		//		var zipData = StaticDatas.zipData;
		//		var query = string.Join(";", listings
		//			.Select(s => $"IF NOT EXISTS (SELECT * FROM fb_users WHERE ID = '{s.marketplace_listing_seller.id}')" +
		//			$"INSERT INTO fb_users " +
		//			$"VALUES('{s.marketplace_listing_seller.id}', '{s.marketplace_listing_seller.name}', GETUTCDATE());" +
		//			$"IF NOT EXISTS (SELECT * FROM locations WHERE zipcode = {zipData.zipcode} and category='{StaticDatas.category}' and [user_id]='{s.marketplace_listing_seller.id}') " +
  //                  $"INSERT INTO locations(zipcode, state, city, category, user_id)" +
		//			$"VALUES({s.location.reverse_geocode.lo}, '{zipData.state}', '{zipData.city}', '{StaticDatas.category}', '{s.marketplace_listing_seller.id}')"));


		//		var rowAffected = await db.ExecuteAsync(query);
		//		Console.Clear();
		//		Console.WriteLine($"Page {StaticDatas.page}\nTotal Records {StaticDatas.records}\nErrors {StaticDatas.error}\nCategory {StaticDatas.category} in {StaticDatas.zipData.zipcode}\nCurrent Db Row Affected {rowAffected}");
		//	}
			
  //      }


		static public bool insertUser(string id,string name)
			=> getConnection()
				.QuerySingle<bool>("IF NOT EXISTS (SELECT 1 FROM scraped_database WHERE ID=@id) BEGIN insert into scraped_database(id,[name],[date]) values(@id,@name,GETUTCDATE()) select(0) END ELSE IF NOT EXISTS (SELECT 1 FROM scraped_database WHERE ID=@id and user_join is not null) Select(0) ELSE select(1)",new
                {
					id,
					name
                });

		static public bool updateCategory(MarketPlaceResultLocation.MarketPlaceResultGeocode geocode,string id)
			=> getConnection()
			.QuerySingle<bool>("IF NOT EXISTS (SELECT 1 FROM scraped_location WHERE city=@city and [state]=@state and category=@category and [user]=@user) BEGIN INSERT INTO scraped_location(city,state,category,[user]) VALUES(@city,@state,@category,@user) SELECT(1) END ELSE SELECT(0)", new
            {
				geocode.city,
				geocode.state,
				category=StaticDatas.category,
				user=id
            });

		static public void updateRating(MarketPlaceItemSeller user)
			=> getConnection()
			.Execute("UPDATE scraped_database SET user_join=DATEADD(s, @join, '1970-01-01'),rating_count=@count,avg_rating=@avg Where id=@id", new
			{
				join = user.join_time,
				count = user.marketplace_ratings_stats_by_role.seller_stats.five_star_total_rating_count_by_role,
				avg = user.marketplace_ratings_stats_by_role.seller_stats.five_star_ratings_average,
				id=user.id
			});


		private static SqlConnection getConnection()
			=> new SqlConnection(Settings.sql_connection_string);



	}
}

