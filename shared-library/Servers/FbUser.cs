using System;
using System.ComponentModel.DataAnnotations;
using Azure;
using Azure.Data.Tables;

namespace shared_library.Servers
{
	public class FbUser
	{
        public FbUser()
        {

        }
        public string id { get; set; }
        public string name { get; set; }
        public DateTime ?last_updated { get; set; }
    }

    public class FbLocation
    {
        [Key]
        public int  id { get; set; }
        public int zipcode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string category { get; set; }
        public string user_id { get; set; }
    }

}

