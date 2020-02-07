import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClientModule, HttpClient, HttpResponseBase, HttpResponse } from '@angular/common/http';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';

export const BASE_URL = new InjectionToken<string>('BASE_URL');

@Injectable({ providedIn: 'root' })
export class BaseHttpServiceService {
	constructor(httpClient: HttpClientModule) {}
}

@Injectable()
export class AuthService {
	private http: HttpClient;
	private baseUrl: string;

	constructor(
		@Inject(HttpClient) http: HttpClient,
		@Optional()
		@Inject(BASE_URL)
		baseUrl?: string
	) {
		this.http = http;
		this.baseUrl = baseUrl ? baseUrl : 'https://localhost:44300/api/v1';
	}
	isAuthorized(): Observable<boolean> {
		let token = localStorage.getItem('token');
		if (token !== undefined && token !== '' && token !== null) {
			return _observableOf(true);
		}
		return _observableOf(false);
	}
	async login(loginRequest: LoginRequest): Promise<Observable<LoginResponse>> {
		let url = this.baseUrl + '/oauth/login';
		if (loginRequest.username === undefined || loginRequest.password === undefined) {
			let loginResponse: LoginResponse = {
				token: '',
				refreshToken: '',
				isSuccess: false,
				errors: [ 'Credentials not specified' ]
			};
			return new Observable(loginResponse as any);
		}
		let options: any = {
			body: loginRequest
		};
		return this.http
			.request('post', url, options)
			.pipe(
				_observableMergeMap((response: any) => {
					return this.processLoginRequest(response);
				})
			)
			.pipe(
				_observableCatch((response: any) => {
					if (response instanceof HttpResponseBase) {
						try {
							return this.processLoginRequest(<any>response);
						} catch (e) {
							return <Observable<LoginResponse>>(<any>_observableThrow(e));
						}
					} else {
						return <Observable<LoginResponse>>(<any>_observableThrow(response));
					}
				})
			);
	}

	processLoginRequest(response: any): Observable<LoginResponse> {
		const status = response.success;
		if (status === true) {
			localStorage.setItem('token', response.token);
			localStorage.setItem('refreshToken', response.refreshToken);
			let loginResponse: LoginResponse = {
				token: response.token,
				refreshToken: response.refreshToken,
				isSuccess: true,
				errors: []
			};
			return _observableOf(loginResponse);
		}

		return _observableOf<LoginResponse>(<any>null);
	}
}

@Injectable()
export class IssueService {
	private http: HttpClient;
	private baseUrl: string;

	constructor(
		@Inject(HttpClient) http: HttpClient,
		@Optional()
		@Inject(BASE_URL)
		baseUrl?: string
	) {
		this.http = http;
		this.baseUrl = baseUrl ? baseUrl : 'https://localhost:44300/api/v1/issue';
	}
	login(projectId: string): Observable<IssueDto[]> {
		let url = this.baseUrl + '/all?projectId=';
		if (projectId === '') {
			return new Observable(<any>null);
		}
		url += projectId;
		return this.http
			.request('get', url)
			.pipe(
				_observableMergeMap((response: any) => {
					return this.processLoginRequest(response);
				})
			)
			.pipe(
				_observableCatch((response: any) => {
					if (response instanceof HttpResponseBase) {
						try {
							return this.processLoginRequest(<any>response);
						} catch (e) {
							return <Observable<IssueDto[]>>(<any>_observableThrow(e));
						}
					} else {
						return <Observable<IssueDto[]>>(<any>_observableThrow(response));
					}
				})
			);
	}

	processLoginRequest(response: any): Observable<IssueDto[]> {
		return _observableOf(response as IssueDto[]);
	}
}

export interface IssueCommentDto {
	createdAt?: Date;
	creatorId?: string;
	text?: string | undefined;
}
export interface IssueHistoryDto {
	createdAt?: Date;
	changeUserId?: string;
	actionType?: string | undefined;
}
export interface IssueDto {
	name?: string | undefined;
	description?: string | undefined;
	acceptanceTests?: string | undefined;
	reproduction?: string | undefined;
	createdAt?: Date;
	creatorUserId?: string;
	modifiedAt?: Date;
	issueHistories?: IssueHistoryDto[] | undefined;
	issueNumber?: number;
	issueFullNumber?: string | undefined;
	issueComments?: IssueCommentDto[] | undefined;
	loggedTime?: number;
	priority?: string | undefined;
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
