import { Component } from '@angular/core';
import { ShortLinkService } from '../Service/shortLinkService';
import { Link } from '../models/Link';
import { ActivatedRoute } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  link: Link = new Link();
  shortLink: string = '';
  url: string = window.location.origin + '/';
  constructor(private ngxUiLoaderService: NgxUiLoaderService, private shortLinkService: ShortLinkService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.shortLink = params.get("shortLink");
      if (this.shortLink != null && this.shortLink != undefined && this.shortLink != '') {
        this.GetLongLink();
      }
    });
  }

  CreateShortLink() {
    this.ngxUiLoaderService.startLoader("loader");
    this.shortLinkService.CreateShortLink(this.link).subscribe((link: any) => {
      this.link.ShortLink = link.shortLink;
      this.shortLink = link.shortLink;
      this.url += link.shortLink;
      this.ngxUiLoaderService.stopLoader("loader");
    });
  }

  GetLongLink() {
    this.ngxUiLoaderService.startLoader("loader");
    this.shortLinkService.GetLongLink(this.shortLink).subscribe((longLink: string) => {
      location.href = longLink;
      this.ngxUiLoaderService.stopLoader("loader");
    });
  }
}
