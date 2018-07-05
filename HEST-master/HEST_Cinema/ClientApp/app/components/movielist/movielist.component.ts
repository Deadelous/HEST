import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { MovieService } from '../../components/movieservice/movieservice';
import { Movie } from '../Typescriptmodels/movie.component';
import { Router, ActivatedRoute, Params } from "@angular/router";
import { AlertService,  } from '../auth/index';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Component({
    selector: 'movielist',
    templateUrl: './movielist.component.html',
    styleUrls: ['./movielist.component.css'],
    

})
export class MovielistComponent implements OnInit {
    movies: Movie;
    search: string = '';


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private movieservice: MovieService, private router: Router, private alertService: AlertService) {
    
    }

    ngOnInit() {
     this.getMovies();
    }

    getMovies() {
        this.movieservice.getMovies()
            .subscribe(
                data => {
                    this.alertService.success('All movies of HEST Cinema', true);
                },
                error => {
                    console.error(error);
                    this.alertService.error(error);               
                });

        this.http.get(this.baseUrl + "/api/movie/GetAllMovies")
            .map((res: Response) => res.json())
            .subscribe(
                data => { this.movies = data },
                err => console.error(err),
                () => console.log('done')
            );

    }

    getFilteredMovies(movies, search) {
        if (search) {
            search = search.toLowerCase();
        }

        return movies.filter((movie) => {
            var title = movie.title.toLowerCase();
            if (search) {
                return title.indexOf(search) !== -1;
            } else {
                return true;
            }
        });
    }
}

