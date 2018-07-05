import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Account } from '../TypeScriptModels/index';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

    currentAccount: Account;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl) { }

    GetAllAccounts() {
        return this.http.get('api/account/GetAllAccounts', this.jwt()).map((response: Response) => response.json());
    }

    getAccountID(id: any) : Observable<Account>{

        return this.http.get(this.baseUrl + 'api/account/' + id)
            .map((response: Response) => response.json());
    }

    getAccount(email: string) {
        return this.http.get('api/account/getAccount' + email, this.jwt())
            .map((response: Response) => response.json());
    }

    CreateAccount(account: Account) {
        return this.http.post('api/account/createAccount', account, this.jwt()).map((response: Response) => response.json());      
    }

    update(account: Account) {
        return this.http.post(this.baseUrl + 'api/account/UpdateAccount', account)
            .map((response: Response) => response.json());
    }

    deleteAccount(email: string) {
        return this.http.delete('api/account/DeleteAccount' + email, this.jwt())
            .map((response: Response) => response.json());
    }


    private jwt() {
        
        let currentAccount: any = localStorage.getItem('currentAccount');
        this.currentAccount= JSON.parse(currentAccount);
        if (currentAccount && currentAccount.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentAccount.token });
            return new RequestOptions({ headers: headers });
        }
    }
}

