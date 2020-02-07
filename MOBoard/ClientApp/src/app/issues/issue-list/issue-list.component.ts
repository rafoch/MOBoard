import { IssueDto } from './../../common/base-http-service.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html',
  styleUrls: ['./issue-list.component.scss']
})
export class IssueListComponent implements OnInit {
  @Input() list: IssueDto[]
  constructor() { }

  ngOnInit() {
  }

}
