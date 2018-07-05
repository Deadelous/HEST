import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage != undefined) {
            if (localStorage.getItem('currentAccount')) {
                
                return true;
            }
        }

       
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}