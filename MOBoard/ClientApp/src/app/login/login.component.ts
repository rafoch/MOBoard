import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService, LoginResponse, LoginRequest } from '../common/base-http-service.service';
import { Router } from '@angular/router';

@Component({ selector: 'app-login', templateUrl: './login.component.html', styleUrls: [ './login.component.scss' ] })
export class LoginComponent implements OnInit, OnDestroy {
	public login: string = 'zaq1@WSX';
	public password: string = 'zaq1@WSX';
	public response: LoginResponse;
	private _authService: AuthService;
	constructor(private authService: AuthService, private _router: Router) {
		this._authService = authService;
	}

	ngOnInit() {}

	ngOnDestroy(): void {}

	async authorize() {
		let loginRequest: LoginRequest = {
			username: this.login,
			password: this.password
		};
		await (await this._authService.login(loginRequest)).subscribe((response) => (this.response = response));
	}

	isAuthorized() {
		let isUserAuthorized = false;
		this._authService.isAuthorized().subscribe((isAuthorized) => (isUserAuthorized = isAuthorized));
		return isUserAuthorized;
	}
}
