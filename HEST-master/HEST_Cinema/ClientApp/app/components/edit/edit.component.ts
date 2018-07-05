import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AlertService, UserService } from '../auth/index';

@Component({

    selector: 'edit',
    templateUrl: 'edit.component.html'
})

export class EditComponent {
    account: any = {};
    loading = false;

    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService) { }

        edit() {
        this.loading = true;
        this.userService.update(this.account)
            .subscribe(
                data => {
                    this.alertService.success('Account edit succesful', true);                  
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}
