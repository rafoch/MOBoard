import { IssuesComponent } from "./issues.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: IssuesComponent
  },
  {}
];

@NgModule({
  declarations: [IssuesComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IssuesModule {}
