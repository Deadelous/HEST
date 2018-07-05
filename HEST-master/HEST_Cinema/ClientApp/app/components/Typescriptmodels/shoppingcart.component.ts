import { CartItem } from '../Typescriptmodels/cartitem.component'

export class MovieCart {
    public items: CartItem[] = new Array<CartItem>(); 
    public itemsTotal: number = 0;

    public updateFrom(src: MovieCart) {
        this.items = src.items;
        this.itemsTotal = src.itemsTotal;
    }
}