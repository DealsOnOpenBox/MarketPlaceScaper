using System;
namespace shared_library.Clients
{
	public class MarketPlaceResult
	{
        public MarketPlaceResultData data { get; set; }

        public IEnumerable<MarketPlaceResultListingNode> getNodes()
            => data?.marketplace_search?.feed_units?.edges?
            .Where(s => s.node.listing != null)?
            .Select(s => s.node) ?? new List<MarketPlaceResultListingNode>();
    }

	public class MarketPlaceResultData
    {
        public MarketPlaceResultDataSearch marketplace_search { get; set; }

    }

    public class MarketPlaceResultDataSearch
    {
        public MarketPlaceResultFeedUnit feed_units { get; set; }
    }

    public class MarketPlaceResultFeedUnit
    {
        public List<MarketPlaceResultEdge> edges { get; set; }
    }

    public class MarketPlaceResultEdge
    {
        public MarketPlaceResultListingNode node { get; set; }
        

    }

    public class MarketPlaceResultListing
    {
        public string id { get; set; }
        public MarketPlaceResultLocation location { get; set; }
        public MarketPlaceResultSeller marketplace_listing_seller { get; set; }

    }

    public class MarketPlaceResultListingNode
    {
        public MarketPlaceResultListing listing { get; set; }
        public string tracking { get; set; }
        public string story_type { get; set; }
    }

    public class MarketPlaceResultLocation
    {
        public class MarketPlaceResultGeocode
        {
            public string city { get; set; }
            public string state { get; set; }
        }

        public MarketPlaceResultGeocode reverse_geocode { get; set; }
    }

    public class MarketPlaceResultSeller
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}

