import {
	IssueService,
	IssueDto,
	ProjectService,
	GetProjectForUserResponse
} from './../common/base-http-service.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { SearchSelectComponent } from '../common/search-select/search-select.component';

@Component({
	selector: 'app-issues',
	templateUrl: './issues.component.html',
	styleUrls: [ './issues.component.scss' ]
})
export class IssuesComponent implements OnInit {
	public issueList: Observable<IssueDto[]>;
	public projects: Observable<GetProjectForUserResponse[]>;
	private oldId: string;
	@ViewChild(SearchSelectComponent, { static: true })
	child: SearchSelectComponent;
	closeChild: boolean;
	constructor(private _issueService: IssueService, private _projectService: ProjectService) {}

	ngOnInit() {
		this.projects = this._projectService.my();
	}

	selectProject(id: string) {
		this.child.toggleDisplay();
		if (this.oldId === id) {
			return;
		}
		this.oldId = id;
		this.issueList = this._issueService.login(id);
		this.closeChild = true;
	}
}
