import { Component } from '@angular/core';
import { AuthService, LoginRequest } from "./common/base-http-service.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  response: any = "empty";
  private _authService: AuthService;

  constructor(authService: AuthService) {
    this._authService = authService;
  }

  authorize() {
    console.log("Trying Authorize");
    console.log(this._authService);
    let loginRequest: LoginRequest = {
      username: 'zaq1@WSX',
      password: 'zaq1@WSX'
    };
    console.log(loginRequest);
    this._authService.login(loginRequest).subscribe(test => {
      debugger;
      console.log("Login successfully");
      this.response = test;
    });
  }

}
