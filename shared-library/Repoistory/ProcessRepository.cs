//using System;
//using shared_library.Clients;
//using shared_library.Contexts;
//using shared_library.Servers;

//namespace shared_library.Repoistory
//{
//	public interface IProcessRepository
//    {

//        Task insertUsers(List<ParseUserData> parseUserDatas);

//    }

//	public class ProcessRepository:IProcessRepository
//	{
//		private readonly MainContext mainContext;
//        public ProcessRepository(MainContext mainContext)
//        {
//            this.mainContext = mainContext;
//        }

//        public async Task insertUsers(List<ParseUserData> parseUserDatas)
//        {
//            var newUserIds = parseUserDatas.Select(c => c.data.user.id);

//            var alreadyInsertedUsers = mainContext
//                .scrapedUsers
//                .Select(s => s.id)
//                .Where(s => newUserIds.Contains(s))
//                .ToList();

//            var toInsertUsers = parseUserDatas
//                .Where(s => !alreadyInsertedUsers.Contains(s.data.user.id))
//                .ToList();

//            foreach (var user in toInsertUsers)
//                mainContext.scrapedUsers.Add(parseUser(user.data.user));

//            await mainContext.SaveChangesAsync();
            
//        }


//        private ScrapedUser parseUser(ParseUserData.User data)
//        {
//            var user = new ScrapedUser();
//            user.id = data.id;
//            user.name = data.name;
//            user.date_added = DateTime.UtcNow;

//            #region contact-parse
//            var merchant = data.commerce_merchant_settings.customer_service_information;
//            var address = merchant.address;
//            user.contact_info.business_type = merchant.business_type;
//            user.contact_info.email = merchant.email;
//            user.contact_info.phone_number = merchant.phone_number?.ToString();
//            user.contact_info.address.city = address.city;
//            user.contact_info.address.state = address.state;
//            user.contact_info.address.postal_code = address.postal_code;
//            user.contact_info.address.street_1 = address.street_1;
//            user.contact_info.address.street_2 = address.street_2;
//            #endregion


//            #region market-place-parse
//            var stats = data.marketplace_ratings_stats_by_role;
//            user.marketlace.marketplace_id = data.commerce_merchant_settings.id;
//            user.marketlace.five_star_ratings_average = (float)stats.seller_stats.five_star_ratings_average;
//            user.marketlace.five_star_total_rating_count_by_role = (float)stats.seller_stats.five_star_total_rating_count_by_role;
//            #endregion
//            return user;

//        }



//    }
//}

