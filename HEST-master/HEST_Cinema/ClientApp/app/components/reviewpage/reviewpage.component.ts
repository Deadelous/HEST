import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Review } from '../Typescriptmodels/review.component';
import { Router, ActivatedRoute, Params } from "@angular/router";

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Component({
    //moduleId: module.id,
    selector: 'reviewpage',
    templateUrl: './reviewpage.component.html',
    styleUrls: ['./reviewpage.component.css']

})
export class ReviewpageComponent {
    reviews: Review;
    search: string = '';


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private router: Router) {

    }

    ngOnInit() {
        this.getReviews();
    }

    getReviews() {
        this.http.get(this.baseUrl + "/api/review/GetReviews")
            .map((res: Response) => res.json())
            .subscribe(
            data => { this.reviews = data },
            err => console.error(err),
            () => console.log('done')
            );

    }
}
