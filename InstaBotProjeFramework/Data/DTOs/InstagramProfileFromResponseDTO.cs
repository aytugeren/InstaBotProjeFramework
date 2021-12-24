using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EdgeFollowedBy
    {
        [JsonProperty("count")]
        public int Count;
    }

    public class EdgeFollow
    {
        [JsonProperty("count")]
        public int Count;
    }

    public class EdgeMutualFollowedBy
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("edges")]
        public List<object> Edges;
    }

    public class PageInfo
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage;

        [JsonProperty("end_cursor")]
        public object EndCursor;
    }

    public class EdgeFelixVideoTimeline
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("page_info")]
        public PageInfo PageInfo;

        [JsonProperty("edges")]
        public List<object> Edges;
    }

    public class EdgeOwnerToTimelineMedia
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("page_info")]
        public PageInfo PageInfo;

        [JsonProperty("edges")]
        public List<object> Edges;
    }

    public class EdgeSavedMedia
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("page_info")]
        public PageInfo PageInfo;

        [JsonProperty("edges")]
        public List<object> Edges;
    }

    public class EdgeMediaCollections
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("page_info")]
        public PageInfo PageInfo;

        [JsonProperty("edges")]
        public List<object> Edges;
    }

    public class UserResponse
    {
        [JsonProperty("biography")]
        public string Biography;

        [JsonProperty("blocked_by_viewer")]
        public bool BlockedByViewer;

        [JsonProperty("restricted_by_viewer")]
        public bool? RestrictedByViewer;

        [JsonProperty("country_block")]
        public bool CountryBlock;

        [JsonProperty("external_url")]
        public object ExternalUrl;

        [JsonProperty("external_url_linkshimmed")]
        public object ExternalUrlLinkshimmed;

        [JsonProperty("edge_followed_by")]
        public EdgeFollowedBy EdgeFollowedBy;

        [JsonProperty("fbid")]
        public string Fbid;

        [JsonProperty("followed_by_viewer")]
        public bool FollowedByViewer;

        [JsonProperty("edge_follow")]
        public EdgeFollow EdgeFollow;

        [JsonProperty("follows_viewer")]
        public bool FollowsViewer;

        [JsonProperty("full_name")]
        public string FullName;

        [JsonProperty("has_ar_effects")]
        public bool HasArEffects;

        [JsonProperty("has_clips")]
        public bool HasClips;

        [JsonProperty("has_guides")]
        public bool HasGuides;

        [JsonProperty("has_channel")]
        public bool HasChannel;

        [JsonProperty("has_blocked_viewer")]
        public bool HasBlockedViewer;

        [JsonProperty("highlight_reel_count")]
        public int HighlightReelCount;

        [JsonProperty("has_requested_viewer")]
        public bool HasRequestedViewer;

        [JsonProperty("hide_like_and_view_counts")]
        public bool HideLikeAndViewCounts;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("is_business_account")]
        public bool IsBusinessAccount;

        [JsonProperty("is_professional_account")]
        public bool IsProfessionalAccount;

        [JsonProperty("is_embeds_disabled")]
        public bool IsEmbedsDisabled;

        [JsonProperty("is_joined_recently")]
        public bool IsJoinedRecently;

        [JsonProperty("business_address_json")]
        public object BusinessAddressJson;

        [JsonProperty("business_contact_method")]
        public object BusinessContactMethod;

        [JsonProperty("business_email")]
        public object BusinessEmail;

        [JsonProperty("business_phone_number")]
        public object BusinessPhoneNumber;

        [JsonProperty("business_category_name")]
        public object BusinessCategoryName;

        [JsonProperty("overall_category_name")]
        public object OverallCategoryName;

        [JsonProperty("category_enum")]
        public object CategoryEnum;

        [JsonProperty("category_name")]
        public object CategoryName;

        [JsonProperty("is_private")]
        public bool IsPrivate;

        [JsonProperty("is_verified")]
        public bool IsVerified;

        [JsonProperty("edge_mutual_followed_by")]
        public EdgeMutualFollowedBy EdgeMutualFollowedBy;

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl;

        [JsonProperty("profile_pic_url_hd")]
        public string ProfilePicUrlHd;

        [JsonProperty("requested_by_viewer")]
        public bool RequestedByViewer;

        [JsonProperty("should_show_category")]
        public bool ShouldShowCategory;

        [JsonProperty("should_show_public_contacts")]
        public bool ShouldShowPublicContacts;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("connected_fb_page")]
        public object ConnectedFbPage;

        [JsonProperty("pronouns")]
        public List<object> Pronouns;

        [JsonProperty("edge_felix_video_timeline")]
        public EdgeFelixVideoTimeline EdgeFelixVideoTimeline;

        [JsonProperty("edge_owner_to_timeline_media")]
        public EdgeOwnerToTimelineMedia EdgeOwnerToTimelineMedia;

        [JsonProperty("edge_saved_media")]
        public EdgeSavedMedia EdgeSavedMedia;

        [JsonProperty("edge_media_collections")]
        public EdgeMediaCollections EdgeMediaCollections;
    }

    public class Graphql
    {
        [JsonProperty("user")]
        public UserResponse User;
    }

    public class ProfilePicEditSyncProps
    {
        [JsonProperty("show_change_profile_pic_confirm_dialog")]
        public bool ShowChangeProfilePicConfirmDialog;

        [JsonProperty("show_profile_pic_sync_reminders")]
        public bool ShowProfilePicSyncReminders;

        [JsonProperty("identity_id")]
        public string IdentityId;

        [JsonProperty("remove_profile_pic_header")]
        public object RemoveProfilePicHeader;

        [JsonProperty("remove_profile_pic_subtext")]
        public object RemoveProfilePicSubtext;

        [JsonProperty("remove_profile_pic_confirm_cta")]
        public object RemoveProfilePicConfirmCta;

        [JsonProperty("remove_profile_pic_cancel_cta")]
        public object RemoveProfilePicCancelCta;

        [JsonProperty("is_business_central_identity")]
        public bool IsBusinessCentralIdentity;

        [JsonProperty("change_profile_pic_actions_screen_header")]
        public List<string> ChangeProfilePicActionsScreenHeader;

        [JsonProperty("change_profile_pic_actions_screen_subheader")]
        public List<string> ChangeProfilePicActionsScreenSubheader;

        [JsonProperty("change_profile_pic_actions_screen_upload_cta")]
        public List<string> ChangeProfilePicActionsScreenUploadCta;

        [JsonProperty("change_profile_pic_actions_screen_remove_cta")]
        public List<string> ChangeProfilePicActionsScreenRemoveCta;

        [JsonProperty("change_profile_pic_actions_screen_cancel_cta")]
        public List<string> ChangeProfilePicActionsScreenCancelCta;
    }

    public class InstagramProfileFromResponseDTO
    {
        [JsonProperty("graphql")]
        public Graphql Graphql;

        [JsonProperty("profile_pic_edit_sync_props")]
        public ProfilePicEditSyncProps ProfilePicEditSyncProps;
    }
}