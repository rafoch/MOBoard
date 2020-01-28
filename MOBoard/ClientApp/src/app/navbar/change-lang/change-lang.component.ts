import { Component, OnInit } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";

@Component({
  selector: "app-change-lang",
  templateUrl: "./change-lang.component.html",
  styleUrls: ["./change-lang.component.scss"]
})
export class ChangeLangComponent implements OnInit {
  private _translateService: TranslateService;
  isHidden = true;
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
    this._translateService.setDefaultLang(lang.alias);
    this.isHidden = false;
  }
  showLangaugeList() {
    this.isHidden = !this.isHidden;
  }
}
