import { AddIssueModalComponent } from "./../add-issue-modal/add-issue-modal.component";
import { IssueService } from "./../common/base-http-service.service";
import { IssuesComponent } from "./issues.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuardService } from "../common/auth-guard.service";
import { IssueListComponent } from "./issue-list/issue-list.component";
import { IssueListItemComponent } from "./issue-list/issue-list-item/issue-list-item.component";
import { CommonModule } from "@angular/common";
import {
  CommonComponentsModule,
  TranslationModule
} from "../common/common.module";
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { HttpClient } from "@angular/common/http";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { MaterialModule } from "../material/material.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
const routes: Routes = [
  {
    path: "",
    component: IssuesComponent,
    canActivate: [AuthGuardService]
  },
  {}
];

@NgModule({
  declarations: [
    IssuesComponent,
    IssueListComponent,
    IssueListItemComponent,
    AddIssueModalComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    RouterModule.forChild(routes),
    CommonComponentsModule,
    TranslationModule
  ],
  exports: [RouterModule, TranslateModule],
  providers: []
})
export class IssuesModule {}
