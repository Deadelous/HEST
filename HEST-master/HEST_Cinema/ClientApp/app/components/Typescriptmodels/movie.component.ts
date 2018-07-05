export class Movie {
    id: any;
    title: string;
    director: string;
    description: string;
    genre: string;
    releasedate: number;
    rating: number;
    poster: string;
    trailer: string;
    price: number;


    constructor(serverMovie: any) {
        this.id = serverMovie.id;
        this.title = serverMovie.title;
        this.director = serverMovie.director;
        this.poster = serverMovie.poster;
        this.description = serverMovie.description;
        this.rating = serverMovie.rating;
        this.releasedate = serverMovie.releaseDate;
        this.genre = serverMovie.genre;
        this.trailer = serverMovie.trailer;
        this.price = serverMovie.price;
    }
}