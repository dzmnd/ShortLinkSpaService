let API: any = {
  baseUrl: '/'
}

API.shortLink = {
  base: '/ShortLink'
}

API.shortLink.createShortLink = API.shortLink.base + "/CreateShortLink";
API.shortLink.getLongLink = API.shortLink.base + "/GetLongLink";

export const shortLinkConfig: any = {
  API: API
}
