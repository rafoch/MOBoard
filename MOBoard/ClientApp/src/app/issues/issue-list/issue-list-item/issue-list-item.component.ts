import { IssueDto } from './../../../common/base-http-service.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-issue-list-item',
  templateUrl: './issue-list-item.component.html',
  styleUrls: ['./issue-list-item.component.scss']
})
export class IssueListItemComponent implements OnInit {

  @Input() issue : IssueDto;
  constructor() { }

  ngOnInit() {
  }

}
