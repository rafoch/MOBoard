import { AuthGuardService } from './auth-guard.service';
import { TooltipDirective } from './directives/toolstrip.directive';
import { NgModule } from '@angular/core';
import { NavButtonComponent } from './nav-button/nav-button.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient } from '@angular/common/http';
import { TruncatePipe } from './pipes/pipes-declarations';
import { SearchSelectComponent } from './search-select/search-select.component';
import { IssueService, ProjectService } from './base-http-service.service';

@NgModule({
	exports: [ TranslateModule ],
	declarations: []
})
export class TranslationModule {}
@NgModule({
	declarations: [ NavButtonComponent, TooltipDirective, TruncatePipe, SearchSelectComponent ],
	imports: [ AngularFontAwesomeModule, TranslationModule ],
	exports: [ NavButtonComponent, TruncatePipe, SearchSelectComponent ],
	providers: [
		AuthGuardService,
		{
			useClass: IssueService,
			provide: IssueService
		},
		{
			useClass: ProjectService,
			provide: ProjectService
		}
	]
})
export class CommonComponentsModule {}
