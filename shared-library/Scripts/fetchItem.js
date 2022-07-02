


async (id, qid) => {
    const resp = await fetch("https://www.facebook.com/api/graphql/", {
        "headers": {
            "accept": "*/*",
            "accept-language": "en-GB,en-US;q=0.9,en;q=0.8",
            "content-type": "application/x-www-form-urlencoded",
            "sec-ch-prefers-color-scheme": "dark",
            "sec-ch-ua": "\"(Not(A:Brand\";v=\"8\", \"Chromium\";v=\"100\"",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "\"macOS\"",
            "sec-fetch-dest": "empty",
            "sec-fetch-mode": "cors",
            "sec-fetch-site": "same-origin",
            "viewport-width": "800",
            "x-fb-friendly-name": "MarketplacePDPContainerQuery",
            "x-fb-lsd": "i-pDruyzliPfpO7zCAL8S6"
        },
        "referrer": "https://www.facebook.com/marketplace/category/apparel?deliveryMethod=local_pick_up&exact=true",
        "referrerPolicy": "strict-origin-when-cross-origin",
        "body": `av=100072277298651&__user=100072277298651&__a=1&__dyn=7AzHK4HwkEng5KbxG4VuC0BVU98nwgU7SbgS3q2ibwNw9G2S7o762S1DwUx609vCxS320om782Cwwwqo465o-cw5MKdwGxu782ly87e2l2Utwwwi831wiEjwZwlo5qfK6E7e58jwGzEaE5e7oqBwJK2W5olwUwgojUlDw-wUws9ovUaU3VBwJCwLyESE2KwkQ0z8c84K2e3u36&__csr=ggOhbnibvljfXqDTfEiADqtLQHtOldTkISgyWP9CQ-UEQGZtq_VJrVJb-jGOaDvkHigCm-qiayoGuh92Fk8BGdBDhoOZGmuu9xPm4agRG3y5okDK9p8jgbujjrlx2q8VEpx6Hyk7EvyrwOwc6263edwwyo5GUG6U5G2O9xt0al1C1Kws8cpU2cBwl86K0yUgxG0P8mg1V8C7EmwhEsw0poUO05jU02gUBy8KbU2pwDw0AFwbO06M80VO031m0uC2Tw0_sw8G&__req=1a&__hs=19165.HYP:comet_pkg.2.1.0.2.0&dpr=2&__ccg=GOOD&__rev=1005728632&__s=cm0nwp:88noz1:uq04lh&__hsi=7112090394854639745-0&__comet_req=15&fb_dtsg=NAcMD5FKWrQ9ObZmhDNR25o-kUMxXfZ-VmiprEIXQqPl7EVIZXGmaTA:11:1654530891&jazoest=25366&lsd=i-pDruyzliPfpO7zCAL8S6&__spin_r=1005728632&__spin_b=trunk&__spin_t=1655912584&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=MarketplacePDPContainerQuery&variables={"UFI2CommentsProvider_commentsKey":"MarketplacePDP","canViewCustomizedProfile":true,"disableDoublePDPFieldFetchFix":false,"feedbackSource":56,"feedLocation":"MARKETPLACE_MEGAMALL","location_latitude":39.2548,"location_longitude":-76.8001,"location_radius":2,"location_vanity_page_id":"108114165883510","pdpContext_isHoisted":false,"pdpContext_trackingData":${JSON.stringify(qid)},"referralCode":"null","relay_flight_marketplace_enabled":false,"scale":2,"targetId":"${id}","useDefaultActor":false,"__relay_internal__pv__GKMarketplacePdpUfiPerfH12022relayprovider":false}&server_timestamps=true&doc_id=5192288110852448`,
        "method": "POST",
        "mode": "cors",
        "credentials": "include"
    });

    return await resp.text();
}