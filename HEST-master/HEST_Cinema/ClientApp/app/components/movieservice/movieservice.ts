import { Movie } from '../Typescriptmodels/movie.component';
import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class MovieService {
    movies: Movie;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl) {
    }

    getMovies(): Observable<Movie> {
        return this.http.get(this.baseUrl + "/api/movie/GetAllMovies")
            .map((res: Response) => {
                let movies = res.json();
                return movies;
            });

    }


    getMovieById(id: any): Observable<Movie> {
        return this.http.get(this.baseUrl + '/api/movie/' + id)
            .map((response: Response) => response.json());
    }

    private parseMovieData(movie) {
        return new Movie(movie);
    }
}