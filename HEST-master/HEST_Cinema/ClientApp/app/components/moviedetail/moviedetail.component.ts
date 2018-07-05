import { Component, Inject, OnInit } from '@angular/core';
import { Router, Routes, RouterModule, ActivatedRoute, CanActivate, Params, ParamMap } from '@angular/router';
import { Movie } from '../Typescriptmodels/movie.component';
import { MovieService } from '../../components/movieservice/movieservice';
import { MoviecartService } from '../../components/movieservice/moviecartservice';
import { Http, Response } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/switchMap';
import { DomSanitizer } from '@angular/platform-browser';
import { MoviePipe } from '../../components/movieservice/moviepipe';

@Component({
    //moduleId: module.id,
    selector: 'moviedetail/:id',
    templateUrl: './moviedetail.component.html',
    styleUrls: ['./moviedetail.component.css']
})
export class MoviedetailComponent implements OnInit {
    id: number;
    movie: Movie;
    sub: any;


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private movieservice: MovieService, private router: Router, private route: ActivatedRoute, private moviepipe: MoviePipe, public sanitizer: DomSanitizer, private movieMVC: MoviecartService) {

    }

    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        if (id !== '0') {
            this.GetMovie(id);
        }

    }

    GetMovie(id: any) {
        this.movieservice.getMovieById(id)
            .subscribe((movie: Movie) => {
                this.movie = movie;
            },
            (err: any) => console.log(err));
    }

    addMovie(id: any, name: string, price: number) {
        this.movieMVC.addMovie(this.movie.id, this.movie.title, this.movie.price);
    }


    goBack() {
        window.history.back();
    }
}