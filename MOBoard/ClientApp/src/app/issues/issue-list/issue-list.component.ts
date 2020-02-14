import { AddIssueModalComponent } from "./../../add-issue-modal/add-issue-modal.component";
import { IssueDto } from "./../../common/base-http-service.service";
import { Component, OnInit, Input, EventEmitter } from "@angular/core";
import { ViewChild } from "@angular/core";
import { Output } from "@angular/core";

@Component({
  selector: "app-issue-list",
  templateUrl: "./issue-list.component.html",
  styleUrls: ["./issue-list.component.scss"]
})
export class IssueListComponent implements OnInit {
  @Input() list: IssueDto[] | any;
  @Input() projectId: string | any;
  @Output() emitter = new EventEmitter<boolean>();
  @ViewChild(AddIssueModalComponent, { static: false })
  private dialog: AddIssueModalComponent;
  constructor() {}

  ngOnInit() {}

  createNew() {
    this.dialog.open(this.projectId);
  }

  onTest(emit) {
    this.emitter.emit(emit);
  }
}
