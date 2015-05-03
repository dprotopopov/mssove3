var googletag = googletag || {};
googletag.cmd = googletag.cmd || [];
(function () {
    var gads = document.createElement('script');
    gads.async = true;
    gads.type = 'text/javascript';
    var useSSL = 'https:' == document.location.protocol;
    gads.src = (useSSL ? 'https:' : 'http:') +
            '//www.googletagservices.com/tag/js/gpt.js';
    var node = document.getElementsByTagName('script')[0];
    node.parentNode.insertBefore(gads, node);
})();

googletag.cmd.push(function () {
    googletag.defineSlot('/26887429/30398989', [160, 600], 'div-gpt-ad-29398989').addService(googletag.pubads());
    googletag.defineSlot('/26887429/30399109', [240, 400], 'div-gpt-ad-29399109').addService(googletag.pubads());
    googletag.defineSlot('/26887429/30399229', [728, 90], 'div-gpt-ad-29399229').addService(googletag.pubads());
    googletag.defineSlot('/26887429/30398869', [728, 90], 'div-gpt-ad-29398869').addService(googletag.pubads());
    googletag.pubads().enableSingleRequest();
    googletag.enableServices();
});
