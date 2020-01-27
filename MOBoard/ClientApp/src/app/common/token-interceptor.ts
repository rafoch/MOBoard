import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor{
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // All HTTP requests are going to go through this method
    let token = localStorage.getItem("token");
    let reqHeaders = req.headers;
    reqHeaders.append('Authorization', 'Bearer ' + token);
    const authReq = req.clone({ headers: reqHeaders });

    return next.handle(authReq);
  }
}
