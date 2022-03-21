import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { ReceptionistComponent } from './receptionist/receptionist.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { ReportsComponent } from './reports/reports.component';
import { BaggageComponent } from './baggage/baggage.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { MobileAppComponent } from './mobile-app/mobile-app.component';
import { HttpClientModule } from '@angular/common/http';
import { TablasComponent } from './tablas/tablas.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    ReceptionistComponent,
    SignInComponent,
    ReportsComponent,
    BaggageComponent,
    SignUpComponent,
    MobileAppComponent,
    TablasComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: SignUpComponent},
      {path: 'admin', component: AdminComponent},
      {path: 'receptionist', component: ReceptionistComponent},
      {path: 'signIn', component: SignInComponent},
      {path: 'baggage', component: BaggageComponent},
      {path: 'report',component:ReportsComponent},
      {path:'mobileApp', component: MobileAppComponent},
      {path: 'tablas', component: TablasComponent}
    ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
