import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { PalindromeCheckComponent } from './components/palindromecheck/palindromecheck.component';
import { PCheckService } from './services/pcheckservice.service'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        PalindromeCheckComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'palindrome-check', component: PalindromeCheckComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[ PCheckService ],
})
export class AppModuleShared {
}
