export class Account {
    id: any;
    firstname: string;
    lastname: string;
    email: string;
    adress: string;
    city: string;
    postalcode: string;
    phonenumber: string;
    username: string;
    credit: number;
    picture: string;
    token: string;


    constructor(serverAccount: any) {
        this.id = serverAccount.id;
        this.firstname = serverAccount.firstname;
        this.lastname = serverAccount.lastname;
        this.email = serverAccount.email;
        this.adress = serverAccount.adress;
        this.city = serverAccount.city
        this.postalcode = serverAccount.postalcode;
        this.phonenumber = serverAccount.phonenumber;
        this.username = serverAccount.username;
        this.credit = serverAccount.credit;
        this.picture = serverAccount.picture;
        this.token = serverAccount.token;
    }
}