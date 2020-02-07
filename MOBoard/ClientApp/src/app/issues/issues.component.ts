import { IssueService, IssueDto } from './../common/base-http-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.scss']
})
export class IssuesComponent implements OnInit {

  public issueList : IssueDto[];
  constructor(private _issueService : IssueService) { }

  ngOnInit() {
    this._issueService.login('DD0BB5BC-A571-4DBF-9CDA-08D782D86CFE').subscribe(i => this.issueList = i);
  }

}
