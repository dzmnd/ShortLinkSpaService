"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var API = {
    baseUrl: '/'
};
API.shortLink = {
    base: '/ShortLink'
};
API.shortLink.createShortLink = API.shortLink.base + "/CreateShortLink";
API.shortLink.getLongLink = API.shortLink.base + "/GetLongLink";
exports.shortLinkConfig = {
    API: API
};
//# sourceMappingURL=shortLink.config.js.map