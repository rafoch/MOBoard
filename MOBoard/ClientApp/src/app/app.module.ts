import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './common/base-http-service.service';
import { TokenInterceptor } from './common/token-interceptor';
import { NavbarComponent } from './navbar/navbar.component';
import { ChangeLangComponent } from './navbar/change-lang/change-lang.component';
import { CommonComponentsModule } from './common/common.module';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { AddProjectModalComponent } from './add-project-modal/add-project-modal.component';

@NgModule({
	declarations: [
		AppComponent,
		NavbarComponent,
		ChangeLangComponent,
		LandingComponent,
		LoginComponent,
		AddProjectModalComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		CommonComponentsModule,
		ReactiveFormsModule,
		FormsModule,
		TranslateModule.forRoot({
			loader: {
				provide: TranslateLoader,
				useFactory: HttpLoaderFactory,
				deps: [ HttpClient ]
			}
		})
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
	bootstrap: [ AppComponent ]
})
export class AppModule {}

export function HttpLoaderFactory(http: HttpClient) {
	return new TranslateHttpLoader(http);
}
