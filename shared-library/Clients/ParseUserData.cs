using System;
namespace shared_library.Clients
{
	public class ParseUserData
	{
		public ParseUserData()
		{
		}
        public Data data { get; set; }
        public Extensions extensions { get; set; }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Address
        {
            public string street_1 { get; set; }
            public string street_2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postal_code { get; set; }
        }

        public class BadAttributesCount
        {
            public int count { get; set; }
            public Title title { get; set; }
        }

        public class CityPage
        {
            public string display_name { get; set; }
            public string id { get; set; }
        }

        public class CommerceBadgesInfo
        {
            public List<object> badges { get; set; }
        }

        public class CommerceMerchantSettings
        {
            public CustomerServiceInformation customer_service_information { get; set; }
            public string id { get; set; }
        }

        public class CommerceProfilePictureWithFallback112
        {
            public string uri { get; set; }
        }

        public class CommerceProfilePictureWithFallback160
        {
            public string uri { get; set; }
        }

        public class CommerceProfilePictureWithFallback50
        {
            public string uri { get; set; }
        }

        public class CommerceProfilePictureWithFallback60
        {
            public string uri { get; set; }
        }

        public class CommerceProfilePictureWithFallback64
        {
            public string uri { get; set; }
        }

        public class CoverPhoto
        {
            public Photo photo { get; set; }
        }

        public class CustomerServiceInformation
        {
            public string __typename { get; set; }
            public Address address { get; set; }
            public string business_type { get; set; }
            public string email { get; set; }
            public object phone_number { get; set; }
        }

        public class DarkIcon
        {
            public string uri { get; set; }
        }

        public class Data
        {
            public User user { get; set; }
            public CommerceBadgesInfo commerce_badges_info { get; set; }
            public Viewer viewer { get; set; }
        }

        public class Edge
        {
            public Node node { get; set; }
            public string cursor { get; set; }
        }

        public class EntityProfilePicture
        {
            public string uri { get; set; }
        }

        public class Extensions
        {
            public List<PrefetchUrisV2> prefetch_uris_v2 { get; set; }
            public bool is_final { get; set; }
        }

        public class GoodAttributesCount
        {
            public int count { get; set; }
            public Title title { get; set; }
        }

        public class GroupCommerceInventory
        {
            public int count { get; set; }
            public List<object> edges { get; set; }
            public PageInfo page_info { get; set; }
        }

        public class Icon
        {
            public string uri { get; set; }
        }

        public class Image
        {
            public int height { get; set; }
            public string uri { get; set; }
            public int width { get; set; }
        }

        public class Items
        {
            public List<Node> nodes { get; set; }
        }

        public class ListingPrice
        {
            public string formatted_amount { get; set; }
            public string amount_with_offset_in_currency { get; set; }
        }

        public class Location
        {
            public ReverseGeocode reverse_geocode { get; set; }
        }

        public class MarketplaceAccountSwitcher
        {
            public bool can_onboard { get; set; }
        }

        public class MarketplaceCommerceInventory
        {
            public int count { get; set; }
            public List<Edge> edges { get; set; }
            public PageInfo page_info { get; set; }
        }

        public class MarketplaceListingSeller
        {
            public string __typename { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }

        public class MarketplaceNuxStates
        {
            public string mp_profile_biz_onboarding_nux { get; set; }
        }

        public class MarketplaceRatingsStatsByRole
        {
            public SellerStats seller_stats { get; set; }
            public bool seller_ratings_are_private { get; set; }
        }

        public class MarketplaceUserProfile
        {
            public string id { get; set; }
            public bool can_viewer_follow { get; set; }
            public bool is_viewer_following { get; set; }
        }

        public class Node
        {
            public string __typename { get; set; }
            public string __isMarketplaceListingRenderable { get; set; }
            public string id { get; set; }
            public ListingPrice listing_price { get; set; }
            public StrikethroughPrice strikethrough_price { get; set; }
            public string __isMarketplaceListingWithComparablePrice { get; set; }
            public object comparable_price { get; set; }
            public object comparable_price_type { get; set; }
            public Location location { get; set; }
            public bool is_hidden { get; set; }
            public bool is_live { get; set; }
            public bool is_pending { get; set; }
            public bool is_sold { get; set; }
            public bool is_viewer_seller { get; set; }
            public object min_listing_price { get; set; }
            public object max_listing_price { get; set; }
            public string marketplace_listing_category_id { get; set; }
            public string marketplace_listing_title { get; set; }
            public object custom_title { get; set; }
            public List<object> custom_sub_titles_with_rendering_flags { get; set; }
            public object origin_group { get; set; }
            public PrimaryListingPhoto primary_listing_photo { get; set; }
            public List<object> pre_recorded_videos { get; set; }
            public string __isMarketplaceListingWithChildListings { get; set; }
            public object parent_listing { get; set; }
            public MarketplaceListingSeller marketplace_listing_seller { get; set; }
            public string __isMarketplaceListingWithDeliveryOptions { get; set; }
            public List<string> delivery_types { get; set; }
        }

        public class Node2
        {
            public Title title { get; set; }
            public Icon icon { get; set; }
            public DarkIcon dark_icon { get; set; }
        }

        public class PageInfo
        {
            public string end_cursor { get; set; }
            public bool has_next_page { get; set; }
        }

        public class Photo
        {
            public string id { get; set; }
            public Image image { get; set; }
        }

        public class PrefetchUrisV2
        {
            public string uri { get; set; }
            public object label { get; set; }
        }

        public class PrimaryListingPhoto
        {
            public string __typename { get; set; }
            public Image image { get; set; }
            public string id { get; set; }
        }

        public class ProfilePicture112
        {
            public string uri { get; set; }
        }

        public class ProfilePicture160
        {
            public string uri { get; set; }
        }

        public class ProfilePicture50
        {
            public string uri { get; set; }
        }

        public class ProfilePicture60
        {
            public string uri { get; set; }
        }

        public class ProfilePicture64
        {
            public string uri { get; set; }
        }

        public class ReverseGeocode
        {
            public string city { get; set; }
            public string state { get; set; }
            public CityPage city_page { get; set; }
        }

        
        public class SellerStats
        {
            public double five_star_ratings_average { get; set; }
            public int five_star_total_rating_count_by_role { get; set; }
            public int min_ratings_required_to_be_public { get; set; }
            public List<GoodAttributesCount> good_attributes_counts { get; set; }
            public List<BadAttributesCount> bad_attributes_counts { get; set; }
        }

        public class StrikethroughPrice
        {
            public string formatted_amount { get; set; }
        }

        public class TimelineContextItems
        {
            public List<object> nodes { get; set; }
        }

        public class Title
        {
            public string text { get; set; }
            public List<object> delight_ranges { get; set; }
            public List<object> image_ranges { get; set; }
            public List<object> inline_style_ranges { get; set; }
            public List<object> aggregated_ranges { get; set; }
            public List<object> ranges { get; set; }
            public List<object> color_ranges { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string __isActor { get; set; }
            public ProfilePicture160 profile_picture_160 { get; set; }
            public ProfilePicture112 profile_picture_112 { get; set; }
            public ProfilePicture64 profile_picture_64 { get; set; }
            public ProfilePicture60 profile_picture_60 { get; set; }
            public ProfilePicture50 profile_picture_50 { get; set; }
            public string __isActorWithCustomizableCommerceProfile { get; set; }
            public CommerceProfilePictureWithFallback160 commerce_profile_picture_with_fallback_160 { get; set; }
            public CommerceProfilePictureWithFallback112 commerce_profile_picture_with_fallback_112 { get; set; }
            public CommerceProfilePictureWithFallback64 commerce_profile_picture_with_fallback_64 { get; set; }
            public CommerceProfilePictureWithFallback60 commerce_profile_picture_with_fallback_60 { get; set; }
            public CommerceProfilePictureWithFallback50 commerce_profile_picture_with_fallback_50 { get; set; }
            public CoverPhoto cover_photo { get; set; }
            public object commerce_cover_photo { get; set; }
            public string name { get; set; }
            public object customized_profile { get; set; }
            public bool can_viewer_report { get; set; }
            public string __isEntity { get; set; }
            public string url { get; set; }
            public MarketplaceUserProfile marketplace_user_profile { get; set; }
            public string short_name { get; set; }
            public EntityProfilePicture entity_profile_picture { get; set; }
            public MarketplaceRatingsStatsByRole marketplace_ratings_stats_by_role { get; set; }
            public MarketplaceCommerceInventory marketplace_commerce_inventory { get; set; }
            public GroupCommerceInventory group_commerce_inventory { get; set; }
            public TimelineContextItems timeline_context_items { get; set; }
            public Items items { get; set; }
            public CommerceMerchantSettings commerce_merchant_settings { get; set; }
            public object marketplace_seller_custom_vacation_mode_message { get; set; }
            public object marketplace_seller_vacation_mode_enabled { get; set; }
        }

        public class Viewer
        {
            public MarketplaceAccountSwitcher marketplace_account_switcher { get; set; }
            public MarketplaceNuxStates marketplace_nux_states { get; set; }
        }



    }


}

