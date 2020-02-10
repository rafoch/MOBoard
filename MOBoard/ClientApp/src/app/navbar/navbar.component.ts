import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../common/base-http-service.service';
import { ModalComponent } from '../common/modal/modal.component';
import { AddProjectModalComponent } from '../add-project-modal/add-project-modal.component';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: [ './navbar.component.scss' ]
})
export class NavbarComponent implements OnInit {
	@ViewChild(AddProjectModalComponent, { static: false })
	private dialog: AddProjectModalComponent;
	private _authService: AuthService;
	constructor(private authService: AuthService) {
		this._authService = authService;
	}
	ngOnInit() {}

	logout() {
		this._authService.logout();
	}

	isAuthorized(): boolean {
		let isUserAuthorized = false;
		this._authService.isAuthorized().subscribe((authorized) => (isUserAuthorized = authorized));
		return isUserAuthorized;
	}

	createNew() {
		this.dialog.open();
	}
}
