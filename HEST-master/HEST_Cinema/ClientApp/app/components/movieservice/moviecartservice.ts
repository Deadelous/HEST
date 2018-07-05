import { Injectable } from "@angular/core";
import { LocalStorageService } from '../movieservice/storageservice.component';
import { Observable } from "rxjs/Observable";
import { Observer } from "rxjs/Observer";
import { CartItem } from '../../components/Typescriptmodels/cartitem.component'
import { Movie } from '../../components/Typescriptmodels/movie.component';
import { MovieCart } from '../../components/Typescriptmodels/moviecart.component';
import { MovieService } from '../movieservice/movieservice';

@Injectable()
export class MoviecartService {
    myCart: any[] = [];
    movie: Movie;

    getCart() {
      return  Promise.resolve(this.myCart);
    }

    addMovie(id: any, name: string, price: number) {
        this.myCart.push({ 'id': id, 'name': name, 'price': Number(price)})
        alert(`${name} added to cart`)
    }

    removeCart(searchId: string) {
        let tmp = this.myCart.map(x => x.id).indexOf(searchId);

        if (tmp > -1) {
            this.myCart.splice(tmp, 1);
        }
    }
}