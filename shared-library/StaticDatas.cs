using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp;
using shared_library.Contexts;
using static shared_library.StaticMethods;

namespace shared_library
{
	static public class StaticDatas
	{
		static public Page page;
		static public string getItemById = File.ReadAllText("Scripts/fetchitem.js");
		static public Dictionary<string, string> headers;
		static public bool keepFetching = true;
		static public ZipcodeData zipData;
		static public string category = "";
		static public int pageCount = 0, records = 0, error = 0;
		static public DateTime? lastFetched;
		public static Dictionary<string, string> fbCategories = new Dictionary<string, string>()
		{
			{"Clothing","apparel"},
			{"Classifieds","classifieds"},
			{"Electronics","electronics"},
			{"Entertainment","entertainment"},
			{"Family","family"},
			{"Free stuff","free"},
			{"Garden and outdoors","garden"},
			{"Hobbies","hobbies"},
			{"Home goods","home"},
			{"Home improvement supplies","home-improvements"},
			{"Property for sale","propertyforsale"},
			{"Musical instruments","instruments"},
			{"Office supplies","office-supplies"},
			{"Pet supplies","pets"},
			{"Property for rent","propertyrentals"},
			{"Sporting goods","sports"},
			{"Toys & games","toys"},
			{"Vehicles","vehicles"}
		};

		public static string getLocationScript(ZipcodeData zipcode)
		{
			var headers = StaticDatas.headers;
			var bodyList = new[]
			{
				"av=100072277298651",
				"__user=100072277298651",
				"__a=1",
				"__dyn=7AzHK4HwkEng5KbxG4VuC0BVU98nwgUb85N3odE98K360CEbotwsobo6u3y4o0B-q7oc81xoswaq221FwgolzUO0n2US2G5Usw9m8wsU9kbxS2218wc61axe3S68f85qfK6E7e58jwGzEaE5e7oqBwJK2W5olwUwOzEjUlDw-wUws9ovUaU6a0BFobpEbUGdwb61jg2cwMwiU8UdU",
				"__csr=gRdnN2kjpmGmR4tkxln8yW8TerdYQWlThh4BmD8GRBETnQBh9fncFaFf8uZZ4ajCt4FS5Ahmt7FeuVqzAayvhiqy4iiUCeyk4uEKU9-UDBGUOex28xei5bUiLzEC8CyocoS79ei8z8zypUeoiwxxm7Vo8oOcAwHwIw_yK2G48jwMWwAxjAxK2mfwi41fw_wJwUg2Exa3e2-0na2K1tw50wIzU2QwIw0Daw47wmGw1vu3604-i00zKjw08T614Uuw8-1Yx-U07RBw0IBg0O60sm8wi8",
				"__req=li",
				"__hs=19155.HYP:comet_pkg.2.1.0.2.",
				"dpr=2",
				"__ccg=MODERATE",
				"__rev=1005671770",
				"__s=bxr3rl:swt5sd:5un4dk",
				"__hsi=7108300986646314155-0",
				"__comet_req=1",
				"fb_dtsg=NAcPbaO7Z6TJYsGwGSDkxAcO3cNJA-PbiahCFjX_AayxoZeWJ1VOEvg:11:1654530891",
				"jazoest=25467",
				"lsd=6gbghBUMwbWrnIHcztQ8PI",
				"__spin_r=1005671770",
				"__spin_b=trunk",
				"__spin_t=1655030294",
				"fb_api_caller_class=RelayModern",
				"fb_api_req_friendly_name=CometMarketplaceSetBuyLocationMutation",
				"variables="+WebUtility.UrlEncode("{\"input\":{\"latitude\":"+zipcode.latitude+",\"longitude\":"+zipcode.longitude+",\"actor_id\":\"100072277298651\",\"client_mutation_id\":\"2\"}}"),
				"server_timestamps=true",
				"doc_id=2731545890190727",
				"fb_api_analytics_tags="+WebUtility.UrlEncode("[\"qpl_active_flow_ids=931594241\"]"),
			};

			var body = string.Join("&", bodyList);
			return "() => {  fetch(\"https://www.facebook.com/api/graphql/\", {    headers: {      accept: \"*/*\",      \"accept-language\": \"en-GB,en-US;q=0.9,en;q=0.8\",      \"content-type\": \"application/x-www-form-urlencoded\",      \"sec-ch-prefers-color-scheme\": \"dark\",      \"sec-ch-ua\": '\"(Not(A:Brand\";v=\"8\", \"Chromium\";v=\"100\"',      \"sec-ch-ua-mobile\": \"?0\",      \"sec-ch-ua-platform\": '\"macOS\"',      \"sec-fetch-dest\": \"empty\",      \"sec-fetch-mode\": \"cors\",      \"sec-fetch-site\": \"same-origin\",      \"viewport-width\": \"800\",      \"x-fb-friendly-name\": \"CometMarketplaceSetBuyLocationMutation\",      \"x-fb-lsd\": \"2i9d5QxKt1O3ubMkqwSomj\",    },    referrer: \"https://www.facebook.com/marketplace/?ref=bookmark\",    referrerPolicy: \"strict-origin-when-cross-origin\",    body: \""+body+"\",    method: \"POST\",    mode: \"cors\",    credentials: \"include\",  })    .then((s) => s.json())    .then((s) => alert(\"Zipcode Updated\"));}";
		}



		public static string getUserDataScript(string id)
			=> "async () => {  const resp = await fetch(\"https://www.facebook.com/api/graphql/\", {    headers: {      accept: \"*/*\",      \"accept-language\": \"en-GB,en-US;q=0.9,en;q=0.8\",      \"content-type\": \"application/x-www-form-urlencoded\",      \"sec-ch-prefers-color-scheme\": \"dark\",      \"sec-ch-ua\": '\"(Not(A:Brand\";v=\"8\", \"Chromium\";v=\"100\"',      \"sec-ch-ua-mobile\": \"?0\",      \"sec-ch-ua-platform\": '\"macOS\"',      \"sec-fetch-dest\": \"empty\",      \"sec-fetch-mode\": \"cors\",      \"sec-fetch-site\": \"same-origin\",      \"viewport-width\": \"800\",      \"x-fb-friendly-name\": \"MarketplaceSellerProfileDialogQuery\",      \"x-fb-lsd\": \"mh-k7NMvpVSvJVzJrUmA6w\",    },    referrer:      \"https://www.facebook.com/marketplace/item/538277234502141/?ref=category_feed&referral_code=marketplace_search&referral_story_type=listing&tracking=%7B%22qid%22%3A%22-6181531128665485720%22%2C%22mf_story_key%22%3A%225579174975426308%22%2C%22commerce_rank_obj%22%3A%22%7B%5C%22target_id%5C%22%3A5579174975426308%2C%5C%22target_type%5C%22%3A0%2C%5C%22primary_position%5C%22%3A8%2C%5C%22ranking_signature%5C%22%3A5550540949932736512%2C%5C%22commerce_channel%5C%22%3A504%2C%5C%22value%5C%22%3A0.00034927479544634%7D%22%2C%22ftmd_400706%22%3A%22111112l%22%7D\",    referrerPolicy: \"strict-origin-when-cross-origin\",    body: \"av=100072277298651&__user=100072277298651&__a=1&__dyn=7AzHK4HwkEng5KbxG4VuC0BVU98nwgUb852bgS3q2ibwNw9G2S7o762S1DwUx609vCxS320om782Cwwwqo465o-cw5MKdwGxu782ly87e2l2Utwwwi831wiEjwPyoowYwlE-UqwsUkxe2GewGwkUtxGm2SUbElxm3y11xfxmu3W3y1MBx_wHwfCm2Sq2-azo2NwkQ0z8c84K2e3u&__csr=gL6nZO8gN2cGltKIAp9nkgF3T4arlfvkDq9_tkQkOhp6h5KyTZqdDF35hikWyvqRGUHefDKl5DGl4UGcpaLyXBBLDUCbLWxqexWEmCx_yUiz9_AVGAGq4VUJfjDy8swyGdxm2G329xC11g4m2G2m4WwmVo5e2K3C488okzES0P8dVo982HwdG0SokwaC0gq0P89pE7-0Z85i0ecgGbw0YRg07Ti03Dm3y4mU8U3Uw08qG04So0p2w7lw9q0k63y&__req=12&__hs=19153.HYP%3Acomet_pkg.2.1.0.2.&dpr=2&__ccg=GOOD&__rev=1005664968&__s=1plj7q%3Amomn4t%3Ala3niv&__hsi=7107644085448523606-0&__comet_req=1&fb_dtsg=NAcN4o_B9LDw82vsktMnlfA8VoZr2CPtX7IaD1I80OcFcSxDJANoUBQ%3A11%3A1654530891&jazoest=25279&lsd=mh-k7NMvpVSvJVzJrUmA6w&__spin_r=1005664968&__spin_b=trunk&__spin_t=1654877347&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=MarketplaceSellerProfileDialogQuery&variables=%7B%22canViewCustomizedProfile%22%3Atrue%2C%22count%22%3A8%2C%22isCOBMOB%22%3Afalse%2C%22scale%22%3A2%2C%22sellerId%22%3A%22"+id+"%22%7D&server_timestamps=true&doc_id=4921892037933898\",    method: \"POST\",    mode: \"cors\",    credentials: \"include\",  });  return await resp.json();}";



	}
}

