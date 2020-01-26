import { Injectable } from "@angular/core";
import { map } from 'rxjs/operators';
import { Http, Response } from '@angular/http';
import { shortLinkConfig } from "../../shortLink.config";
import { Link } from "../models/Link";

@Injectable()
export class ShortLinkService {
  api: any;
  constructor(private http: Http) {
    this.api = shortLinkConfig.API;
  }
  CreateShortLink(link: Link) {
    return this.http.post(this.api.shortLink.createShortLink, link)
      .pipe(map((res: Response) => {
        return res.json();
      }));
  }
  GetLongLink(shortLink: string) {
    return this.http.get(`${this.api.shortLink.getLongLink}?shortLink=${encodeURIComponent(shortLink)}`)
      .pipe(map((res: Response) => {
        return res.json();
      }));
  }
}
