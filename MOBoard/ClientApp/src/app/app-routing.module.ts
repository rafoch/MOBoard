import { LandingComponent } from "./landing/landing.component";
import { AppComponent } from "./app.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: LandingComponent
  },
  {
    path: "issues",
    loadChildren: async () =>
      import("./issues/issues.module").then(m => m.IssuesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
