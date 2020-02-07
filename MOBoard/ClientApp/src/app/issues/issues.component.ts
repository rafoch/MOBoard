import { IssueService, IssueDto } from './../common/base-http-service.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Component({
	selector: 'app-issues',
	templateUrl: './issues.component.html',
	styleUrls: [ './issues.component.scss' ]
})
export class IssuesComponent implements OnInit {
	public issueList: Observable<IssueDto[]>;
	constructor(private _issueService: IssueService) {}

	ngOnInit() {
		this.issueList = this._issueService.login('DAC021E9-DA59-4268-4B84-08D7A113077C');
	}
}
