import {LandingComponent} from "./landing/landing.component";
import {AppComponent} from "./app.component";
import {NgModule} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {LoginComponent} from './login/login.component';

const routes: Routes = [
    {
        path: "",
        component: LandingComponent
    }, {
        path: "login",
        component: LoginComponent
    }, {
        path: "issues",
        loadChildren: async () => import ("./issues/issues.module").then(m => m.IssuesModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
