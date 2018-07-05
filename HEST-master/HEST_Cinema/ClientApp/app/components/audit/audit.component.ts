import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { AuditoriumService } from '../../components/movieservice/auditoriumservice';
import { Auditorium } from '../Typescriptmodels/auditorium.component';
import { Router, ActivatedRoute, Params } from "@angular/router";
import { AlertService, } from '../auth/index';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';


@Component({
    selector: 'audit',
    templateUrl: './audit.component.html',
 
})
export class AuditComponent implements OnInit {
    auditoriums: Auditorium
    search: string = '';


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private auditoriumservice: AuditoriumService, private router: Router, private alertService: AlertService) {

    }

    ngOnInit() {
        this.getAuditoriums();
    }


    getAuditoriums() {
        this.auditoriumservice.getAuditoriums()
            .subscribe(
            data => {
                this.alertService.success('All Auditoriums of HEST Cinema', true);
            },
            error => {
                console.error(error);
                this.alertService.error(error);
            });

        this.http.get(this.baseUrl + "/api/auditorium/GetAuditoriums")
            .map((res: Response) => res.json())
            .subscribe(
            data => { this.auditoriums = data },
            err => console.error(err),
            () => console.log('done')
            );
    }
}

