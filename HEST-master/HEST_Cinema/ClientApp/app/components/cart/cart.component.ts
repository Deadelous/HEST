import { Component, OnInit } from '@angular/core';
import { MoviecartService } from '../../components/movieservice/moviecartservice';
import { Router } from '@angular/router';
import { Movie } from '../../components/Typescriptmodels/movie.component';

@Component({
    selector: 'cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']

})
export class CartComponent implements OnInit {
    movie: Movie;
    myCart: any[];
    cartTotal: any;

    constructor(private movieSVC: MoviecartService, private router: Router) {

    }

    ngOnInit() {
        this.movieSVC.getCart()
            .then(theCart => this.myCart = theCart)
            .then(cart => this.sumCart(cart))
            .then(sum => this.cartTotal = sum);
    }

    sumCart(cart: any) {
        return Promise.resolve(cart.reduce((total: number, movie: Movie) => total + movie.price, 0));
    }

    removeCart(id: any) {
        this.movieSVC.removeCart(id);
        this.sumCart(this.myCart).then(sum => this.cartTotal = sum);
    }

    purchase() {
        alert(`total price ${this.cartTotal}`);
        this.router.navigate(['/home']);
    }

    cancel() {
        this.router.navigate(['/movielist']);
    }
}