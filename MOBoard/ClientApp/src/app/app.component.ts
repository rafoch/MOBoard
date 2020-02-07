import { Component } from "@angular/core";
import { takeUntil, take } from "rxjs/operators";
import { Subject } from "rxjs";
import { AuthService, LoginRequest } from "./common/base-http-service.service";
import { TranslateService } from "@ngx-translate/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent {
  title = "ClientApp";
  response: any = "empty";
  private _onDestroy = new Subject<void>();
  private _authService: AuthService;
  private _translate: TranslateService;

  constructor(authService: AuthService, private translate: TranslateService) {
    this._translate = translate;
    this._translate.setDefaultLang("en");
    this._authService = authService;
  }

  authorize() {
    let loginRequest: LoginRequest = {
      username: "zaq1@WSX",
      password: "zaq1@WSX"
    };
    let observable = this._authService
      .login(loginRequest)
      .subscribe(test => (this.response = test));
  }

  pl() {
    this._translate.use("pl");
  }

  en() {
    this._translate.use("en");
  }
}
