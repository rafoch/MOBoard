import { AuthGuardService } from './auth-guard.service';
import { TooltipDirective } from './directives/toolstrip.directive';
import { NgModule } from '@angular/core';
import { NavButtonComponent } from './nav-button/nav-button.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient } from '@angular/common/http';
import { TruncatePipe } from './pipes/pipes-declarations';

@NgModule({
	exports: [ TranslateModule ]
})
export class TranslationModule {}
@NgModule({
	declarations: [ NavButtonComponent, TooltipDirective, TruncatePipe ],
	imports: [ AngularFontAwesomeModule, TranslationModule ],
	exports: [ NavButtonComponent, TruncatePipe ],
	providers: [ AuthGuardService ]
})
export class CommonComponentsModule {}
