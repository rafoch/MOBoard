import { TranslateService } from "@ngx-translate/core";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styleUrls: ["./navbar.component.scss"]
})
export class NavbarComponent implements OnInit {
  private _translateService: TranslateService;
  isShow = false;
  private _langArray = [
    {
      id: 0,
      alias: "pl",
      name: "Polski"
    },
    {
      id: 1,
      alias: "en",
      name: "English"
    }
  ];
  constructor(private translateService: TranslateService) {
    this._translateService = translateService;
  }

  ngOnInit() {
    this._translateService.setDefaultLang("en");
  }

  changeLang(id: number) {
    let lang = this._langArray[id];
    console.log(lang);
    this._translateService.setDefaultLang(lang.alias);
    this.isShow = false;
  }
  showLangaugeList() {
    console.log(this.isShow);
    this.isShow = !this.isShow;
  }
}
