import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ServerModule } from '@angular/platform-server';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule, ActivatedRoute, CanActivate } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { MovielistComponent } from './components/movielist/movielist.component';
import { MoviedetailComponent } from './components/moviedetail/moviedetail.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProfileComponent } from './components/profile/profile.component';
import { LoginComponent } from './components/login/login.component';
import { ReviewpageComponent } from './components/reviewpage/reviewpage.component';
import { AuditComponent } from './components/audit/audit.component';
import { RegisterComponent } from './components/register/register.component';
import { AlertComponent } from './components/alert/alert.component';
import { ContactComponent } from './components/contact/contact.component';
import { CreditComponent } from './components/credit/credit.component';
import { EditComponent } from './components/edit/edit.component';
import { CartComponent } from './components/cart/cart.component';

import { AuthGuardService as AuthGuard } from './components/auth/index';
import { AuthenticationService } from './components/auth/index';
import { UserService } from './components/auth/index';
import { AlertService } from './components/auth/index';
import { MoviecartService } from './components/movieservice/moviecartservice'
import { MovieService } from './components/movieservice/movieservice';
import { MoviePipe } from './components/movieservice/moviepipe';
import { MovieSearchPipe } from './components/movieservice/moviesearchpipe';
import { LocalStorageService } from './components/movieservice/storageservice.component';

import { AgmCoreModule } from '@agm/core';

@NgModule({
    declarations: [
        AppComponent,
        AlertComponent,
        NavMenuComponent,
        CartComponent,
        CreditComponent,
        ContactComponent,
        EditComponent,
        MoviedetailComponent,
        MovielistComponent,
        HomeComponent,
        FooterComponent,
        ProfileComponent,
        LoginComponent,
        RegisterComponent,
        ReviewpageComponent,
        AuditComponent,
        MovieSearchPipe,
        MoviePipe
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        FormsModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyDBS_5Duy6YlVlIq - 023JxRFMcwkkwD03w'
        }),
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'audit', component: AuditComponent },
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'contact', component: ContactComponent },
            { path: 'credit', component: CreditComponent },
            { path: 'edit', component: EditComponent },
            { path: 'moviedetail/:id', component: MoviedetailComponent },
            { path: 'movielist', component: MovielistComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
            { path: 'reviewpage', component: ReviewpageComponent },
            { path: 'cart', component: CartComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: '' }
        ])
    ],
    providers: [
        AuthGuard,
        AlertService,
        AuthenticationService,
        UserService,
        MovieService,   
        MoviecartService,
        LocalStorageService,
        MovieSearchPipe,
        MoviePipe
    ]
})

export class AppModuleShared {
    static components = [ HomeComponent, ContactComponent, MoviedetailComponent, MovielistComponent, LoginComponent, RegisterComponent, ProfileComponent, ReviewpageComponent];
}

