using System;
using System.ComponentModel.DataAnnotations;

namespace shared_library.Servers
{
	public class ContactInfo
	{
		public ContactInfo()
		{
            this.address = new ContactAddress();
		}


		[Key]
        public int id { get; set; }
        public string business_type { get; set; }
        public string? email { get; set; }
        public string? phone_number { get; set; }
        public ContactAddress? address { get; set; }
    }

	public class ContactAddress
    {
		[Key]
        public int id { get; set; }
        public string? street_1 { get; set; }
        public string? street_2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? postal_code { get; set; }
    }
}

