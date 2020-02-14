import {
  Component,
  OnInit,
  ViewChild,
  Output,
  EventEmitter
} from "@angular/core";
import { ModalComponent } from "../common/modal/modal.component";
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from "@angular/forms";
import {
  IssueService,
  CreateIssueRequest
  // CreateIssueRequest
} from "../common/base-http-service.service";

@Component({
  selector: "app-add-issue-modal",
  templateUrl: "./add-issue-modal.component.html",
  styleUrls: ["./add-issue-modal.component.scss"]
})
export class AddIssueModalComponent implements OnInit {
  @ViewChild(ModalComponent, { static: true })
  dialog: ModalComponent;
  @Output()
  test = new EventEmitter<boolean>();
  projectId: string;
  newIssueForm: FormGroup;

  constructor(fb: FormBuilder, private issueService: IssueService) {
    this.newIssueForm = fb.group({
      name: ["", Validators.required],
      priority: ["", Validators.required],
      description: [""],
      reproduction: [""],
      acceptanceTests: [""]
    });
  }

  ngOnInit() {}

  open(projectId: string) {
    this.projectId = projectId;
    this.dialog.open();
  }

  close() {
    this.dialog.close();
  }
  submitForm() {
    let body: CreateIssueRequest = {
      name: this.newIssueForm.value.name,
      priority: this.newIssueForm.value.priority,
      description: this.newIssueForm.value.description,
      reproduction: this.newIssueForm.value.reproduction,
      acceptanceTests: this.newIssueForm.value.acceptanceTests,
      projectId: this.projectId
    };
    this.issueService.create(body).subscribe(response => this.test.emit(true));
    this.close();
  }
}
