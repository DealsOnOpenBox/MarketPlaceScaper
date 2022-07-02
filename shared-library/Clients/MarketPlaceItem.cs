using System;
namespace shared_library.Clients
{
	public class MarketPlaceItem
	{
        public MarketPlaceItemData data { get; set; }
    }

    public class MarketPlaceItemData
    {
        public MarketPlaceItemViewer viewer { get; set; }
    }

    public class MarketPlaceItemViewer
	{
        public MarketPlaceItemDetail marketplace_product_details_page { get; set; }
    }

	public class MarketPlaceItemDetail
    {
        public MarketPlaceItemTarget target { get; set; }
    }

	public class MarketPlaceItemTarget
    {
        public MarketPlaceItemSeller marketplace_listing_seller { get; set; }

    }


	public class MarketPlaceItemSeller
    {
        public string id { get; set; }
        public string name { get; set; }
        public long join_time { get; set; }
        public MarketPlaceItemStats marketplace_ratings_stats_by_role { get; set; }
    }

    public class MarketPlaceItemStats
    {
        public class Stats
        {
            public float? five_star_ratings_average { get; set; }
            public int? five_star_total_rating_count_by_role { get; set; }
        }
       
        public Stats seller_stats { get; set; }
    }
}

