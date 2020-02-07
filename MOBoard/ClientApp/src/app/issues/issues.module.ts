import { IssueService } from './../common/base-http-service.service';
import { IssuesComponent } from "./issues.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuardService } from '../common/auth-guard.service';
import { IssueListComponent } from './issue-list/issue-list.component';
import { IssueListItemComponent } from './issue-list/issue-list-item/issue-list-item.component';

const routes: Routes = [
  {
    path: "",
    component: IssuesComponent,
    canActivate: [AuthGuardService]
  },
  {}
];

@NgModule({
  declarations: [IssuesComponent, IssueListComponent, IssueListItemComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    {
      provide: IssueService,
      useClass: IssueService
  }
  ]
})
export class IssuesModule {}
