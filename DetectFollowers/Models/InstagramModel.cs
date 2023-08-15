namespace DetectFollowers.Models;

public class InstagramModel
{
    public string biography { get; set; }
    public object[] bio_links { get; set; }
    public object fb_profile_biolink { get; set; }
    public Biography_With_Entities biography_with_entities { get; set; }
    public bool blocked_by_viewer { get; set; }
    public object restricted_by_viewer { get; set; }
    public bool country_block { get; set; }
    public string eimu_id { get; set; }
    public object external_url { get; set; }
    public object external_url_linkshimmed { get; set; }
    public Edge_Followed_By edge_followed_by { get; set; }
    public string fbid { get; set; }
    public bool followed_by_viewer { get; set; }
    public Edge_Follow edge_follow { get; set; }
    public bool follows_viewer { get; set; }
    public string full_name { get; set; }
    public object group_metadata { get; set; }
    public bool has_ar_effects { get; set; }
    public bool has_clips { get; set; }
    public bool has_guides { get; set; }
    public bool has_channel { get; set; }
    public bool has_blocked_viewer { get; set; }
    public int highlight_reel_count { get; set; }
    public bool has_requested_viewer { get; set; }
    public bool hide_like_and_view_counts { get; set; }
    public string id { get; set; }
    public bool is_business_account { get; set; }
    public bool is_professional_account { get; set; }
    public bool is_supervision_enabled { get; set; }
    public bool is_guardian_of_viewer { get; set; }
    public bool is_supervised_by_viewer { get; set; }
    public bool is_supervised_user { get; set; }
    public bool is_embeds_disabled { get; set; }
    public bool is_joined_recently { get; set; }
    public object guardian_id { get; set; }
    public object business_address_json { get; set; }
    public string business_contact_method { get; set; }
    public object business_email { get; set; }
    public object business_phone_number { get; set; }
    public object business_category_name { get; set; }
    public object overall_category_name { get; set; }
    public object category_enum { get; set; }
    public object category_name { get; set; }
    public bool is_private { get; set; }
    public bool is_verified { get; set; }
    public bool is_verified_by_mv4b { get; set; }
    public bool is_regulated_c18 { get; set; }
    public Edge_Mutual_Followed_By edge_mutual_followed_by { get; set; }
    public int pinned_channels_list_count { get; set; }
    public string profile_pic_url { get; set; }
    public string profile_pic_url_hd { get; set; }
    public bool requested_by_viewer { get; set; }
    public bool should_show_category { get; set; }
    public bool should_show_public_contacts { get; set; }
    public bool show_account_transparency_details { get; set; }
    public object transparency_label { get; set; }
    public string transparency_product { get; set; }
    public string username { get; set; }
    public object connected_fb_page { get; set; }
    public object[] pronouns { get; set; }
    public Edge_Felix_Video_Timeline edge_felix_video_timeline { get; set; }
    public Edge_Owner_To_Timeline_Media edge_owner_to_timeline_media { get; set; }
    public Edge_Saved_Media edge_saved_media { get; set; }
    public Edge_Media_Collections edge_media_collections { get; set; }
    public Edge_Related_Profiles edge_related_profiles { get; set; }
}

public class Biography_With_Entities
{
    public string raw_text { get; set; }
    public object[] entities { get; set; }
}

public class Edge_Followed_By
{
    public int count { get; set; }
}

public class Edge_Follow
{
    public int count { get; set; }
}

public class Edge_Mutual_Followed_By
{
    public int count { get; set; }
    public object[] edges { get; set; }
}

public class Edge_Felix_Video_Timeline
{
    public int count { get; set; }
    public Page_Info page_info { get; set; }
    public object[] edges { get; set; }
}

public class Page_Info
{
    public bool has_next_page { get; set; }
    public object end_cursor { get; set; }
}

public class Edge_Owner_To_Timeline_Media
{
    public int count { get; set; }
    public Page_Info1 page_info { get; set; }
    public object[] edges { get; set; }
}

public class Page_Info1
{
    public bool has_next_page { get; set; }
    public string end_cursor { get; set; }
}

public class Edge_Saved_Media
{
    public int count { get; set; }
    public Page_Info2 page_info { get; set; }
    public object[] edges { get; set; }
}

public class Page_Info2
{
    public bool has_next_page { get; set; }
    public object end_cursor { get; set; }
}

public class Edge_Media_Collections
{
    public int count { get; set; }
    public Page_Info3 page_info { get; set; }
    public object[] edges { get; set; }
}

public class Page_Info3
{
    public bool has_next_page { get; set; }
    public object end_cursor { get; set; }
}

public class Edge_Related_Profiles
{
    public object[] edges { get; set; }
}
