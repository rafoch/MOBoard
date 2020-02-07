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
    const cloneReq = req.clone({
      headers: req.headers.set(
        "Authorization",
        "Bearer " + token
      )
    });
    return next.handle(cloneReq);
  }
}
