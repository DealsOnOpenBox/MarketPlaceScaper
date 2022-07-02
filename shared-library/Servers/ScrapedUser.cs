using System;
using System.ComponentModel.DataAnnotations;

namespace shared_library.Servers
{
	public class ScrapedUser
	{
		[Key]
        public string id { get; set; }
        public string name { get; set; }
        public DateTime? user_join { get; set; }
        public DateTime date { get; set; }
        public int? rating_count { get; set; }
        public float? avg_rating { get; set; }
        public List<ScrapedLocation> locations { get; set; }


    }

    public class ScrapedLocation
    {
        [Key]
        public int id { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string category { get; set; }
        public string user { get; set; }
    }


}

