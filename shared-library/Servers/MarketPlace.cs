using System;
using System.ComponentModel.DataAnnotations;

namespace shared_library.Servers
{
	public class MarketPlace
	{
		public MarketPlace()
		{
		}
		[Key]
        public int id { get; set; }
        public string? marketplace_id { get; set; }
        public float? five_star_total_rating_count_by_role { get; set; }
        public float? five_star_ratings_average { get; set; }
        public float? min_ratings_required_to_be_public { get; set; }
        public string? good_attributes { get; set; }
        public string? bad_attributes { get; set; }
        public bool rating_private { get; set; }
        public int? total_items { get; set; }
    }
}

