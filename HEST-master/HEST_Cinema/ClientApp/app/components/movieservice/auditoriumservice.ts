import { Auditorium } from '../Typescriptmodels/auditorium.component';
import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AuditoriumService {
    auditoriums: Auditorium

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl) {
    }

    getAuditoriums(): Observable<Auditorium> {
        return this.http.get(this.baseUrl + "/api/auditorium/GetAuditoriums")
            .map((res: Response) => {
                let auditoriums = res.json();
                return auditoriums;
            });

    }
}