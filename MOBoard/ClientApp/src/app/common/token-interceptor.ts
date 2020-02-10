import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import { AuthService } from './base-http-service.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
	constructor(private router: Router, private authService: AuthService) {}
	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		// All HTTP requests are going to go through this method
		let token = localStorage.getItem('token');
		const cloneReq = req.clone({
			headers: req.headers.set('Authorization', 'Bearer ' + token)
		});
		return next.handle(cloneReq).pipe(
			tap((ev: HttpEvent<any>) => {}),
			catchError(() => {
				this.authService.logout();
				this.router.navigate([ '/login' ]);
			})
		);
	}
}
