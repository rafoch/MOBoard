import { AuthService } from './base-http-service.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{
  private readonly _authService: AuthService;

  constructor(private authService: AuthService, private _router : Router) {
    this._authService = authService;
   }

   canActivate(next : ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    let isUserAuthorized = false;
    this._authService.isAuthorized().subscribe((isAuthorized) => (isUserAuthorized = isAuthorized));
      if(isUserAuthorized){
        return true;
      }

      this._router.navigate(['/login']);

      return false;
   }
}
