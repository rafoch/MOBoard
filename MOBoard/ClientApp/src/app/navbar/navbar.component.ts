import { Component, OnInit } from '@angular/core';
import { AuthService } from '../common/base-http-service.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: [ './navbar.component.scss' ]
})
export class NavbarComponent implements OnInit {
	private _authService: AuthService;
	constructor(private authService: AuthService) {
		this._authService = authService;
	}
	ngOnInit() {}

	isAuthorized(): boolean {
		let isUserAuthorized = false;
		this._authService.isAuthorized().subscribe((authorized) => (isUserAuthorized = authorized));
		console.log('is authorized' + isUserAuthorized);
		return isUserAuthorized;
	}
}
