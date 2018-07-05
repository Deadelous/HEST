import { Component, Inject, OnInit } from '@angular/core';
import { Router, Routes, RouterModule, ActivatedRoute, CanActivate, Params, ParamMap } from '@angular/router';
import { Account } from '../Typescriptmodels/account.component';
import { Http, Response } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/switchMap';
import { AlertService, AuthenticationService, UserService } from '../auth/index';


@Component({
    //moduleId: module.id,
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    accountdetails: any = {};

    constructor(private http: Http,
        @Inject('BASE_URL') private baseUrl: string,
        private auth: AuthenticationService,
        private route: ActivatedRoute,
        private userservice: UserService) {
       
    }
  
}
