import { Component, Inject, OnInit } from '@angular/core';
import { Router, Routes, RouterModule, ActivatedRoute, CanActivate, Params, ParamMap } from '@angular/router';
import { Account } from '../Typescriptmodels/account.component';
import { Http, Response } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/switchMap';
import { AlertService, AuthenticationService, UserService} from '../auth/index';

import { JwtHelper } from 'angular2-jwt';

@Component({
    //moduleId: module.id,
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    //styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    account: any = {};
    accountdetails: any = {};
    email: any;
    token: any;
    private jwtHelper: JwtHelper = new JwtHelper();

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private auth: AuthenticationService, private route: ActivatedRoute, private userservice: UserService) {
        var accountstring = localStorage.getItem('currentAccount');
        this.accountdetails =JSON.parse((localStorage.getItem('currentAccount')) || '{}');
        this.token = localStorage.getItem('id_token');
        console.log(this.accountdetails);
        console.log(this.token);

    }

    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        if (id !== '0') {
            this.GetAccount(id);
        }

    }

    GetAccount(id: any) {
        this.userservice.getAccountID(id)
            .subscribe((account: Account) => {
                    this.account = account;
                },
                (err: any) => console.log(err));
    }
}

