import { Component } from '@angular/core';
import { takeUntil, take } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { AuthService, LoginRequest } from "./common/base-http-service.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  response: any = "empty";
  private _onDestroy = new Subject<void>();
  private _authService: AuthService;

  constructor(authService: AuthService) {
    this._authService = authService;
  }

  authorize() {
    this._authService.test().subscribe(x => console.log(x));
    console.log("Trying Authorize");
    let loginRequest: LoginRequest = {
      username: 'zaq1@WSX',
      password: 'zaq1@WSX'
    };
    let observable = this._authService.login(loginRequest).subscribe(test => this.response = test);
  }

}
