import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService, AuthenticationService } from '../auth/index';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'

})

export class LoginComponent implements OnInit {
    account: any = {};
    loading = false;
    returnUrl: string;

    constructor(
        private http: Http,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.account.email, this.account.password)
        .subscribe(
            data => {
                this.alertService.success('Login successful', true);
                this.router.navigate(['/home']);
            },
            error => {
                console.error(error);
                this.alertService.error(error);
                this.loading = false;

            });
    }
}
