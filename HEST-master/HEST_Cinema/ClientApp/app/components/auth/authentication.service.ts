import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Router, ActivatedRoute } from "@angular/router";
import { Observable, Observer } from 'rxjs';
import 'rxjs/add/operator/map'
import { isPlatformBrowser } from '@angular/common';
import { getBaseUrl } from '../../app.module.browser';
import { AUTH_CONFIG } from './auth0-variables';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthenticationService {

    private currentUser: any;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, route: ActivatedRoute) { }

    login(email: string, password: string) {
        return this.http.post(this.baseUrl + 'api/account/authenticate', { email: email, password: password })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let account = response.json();
                this.currentUser = response.json();
                if (account && account.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentAccount', JSON.stringify(account));
                    console.log(account);
                }
            });
    }

    public getProfile(email: any): Observable<Account> {
        return this.http.get(this.baseUrl + '/api/account/Getaccount' + email)
            .map((response: Response) => response.json());
    }



    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentAccount');
    }
}
