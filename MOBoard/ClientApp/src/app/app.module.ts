import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import {
  HttpClientModule,
  HttpClient,
  HTTP_INTERCEPTORS
} from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AuthService } from "./common/base-http-service.service";
import { TokenInterceptor } from "./common/token-interceptor";
import { NavbarComponent } from "./navbar/navbar.component";
import { ChangeLangComponent } from "./navbar/change-lang/change-lang.component";
import { CommonComponentsModule } from "./common/common.module";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";

@NgModule({
  declarations: [AppComponent, NavbarComponent, ChangeLangComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientModule,
    CommonComponentsModule
  ],
  providers: [
    {
      provide: AuthService,
      useClass: AuthService
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
