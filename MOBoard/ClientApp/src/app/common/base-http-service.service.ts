import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClientModule, HttpClient, HttpResponseBase } from '@angular/common/http';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';

export const BASE_URL = new InjectionToken<string>('BASE_URL');

@Injectable({
  providedIn: 'root'
})
export class BaseHttpServiceService {

  constructor(
    httpClient: HttpClientModule) {

  }
}

@Injectable()
export class AuthService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl ? baseUrl : "https://localhost:44300/api/v1";
  }

  login(loginRequest: LoginRequest): Observable<LoginResponse> {
    let url = this.baseUrl + '/oauth/login';
    if (loginRequest.username === undefined || loginRequest.password === undefined) {
      let loginResponse: LoginResponse = {
        token: "",
        refreshToken: "",
        isSuccess: false,
        errors : ["Credentials not specified"]
      }
      return new Observable((loginResponse) as any);
    }
    let options: any = loginRequest;
    this.http.post(url, options).subscribe((response: any) => {
      return this.processLoginRequest(response);
    });
  }

  processLoginRequest(response): Observable<any> {
    const status = response.success;
    if (status === true) {
      localStorage.setItem("token", response.token);
    }
    return new Observable<any>(<any>response);
  }
}

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  refreshToken: string;
  isSuccess: boolean;
  errors: string[];
}
