import { TooltipDirective } from "./directives/toolstrip.directive";
import { NgModule } from "@angular/core";
import { NavButtonComponent } from "./nav-button/nav-button.component";
import { AngularFontAwesomeModule } from "angular-font-awesome";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { HttpClient } from "@angular/common/http";

@NgModule({
  declarations: [NavButtonComponent, TooltipDirective],
  imports: [
    AngularFontAwesomeModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  exports: [NavButtonComponent, TranslateModule]
})
export class CommonComponentsModule {}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
