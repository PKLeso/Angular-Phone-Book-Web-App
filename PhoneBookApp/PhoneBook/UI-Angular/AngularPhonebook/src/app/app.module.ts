import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { PhonebookComponent } from './phonebook/phonebook.component';
import { AddEditEntryComponent } from './phonebook/add-edit-entry/add-edit-entry.component';
import { ViewPhonebookComponent } from './phonebook/view-phonebook/view-phonebook.component';
import { PhonebookApiService } from './Shared/phonebook-api.service';
import { LoginComponent } from './Auth/login/login.component';
import { ErrorPageComponent } from './shared/error-page/error-page.component';
import { AppRoutingModule } from './app-routing.module';
import { environment } from 'src/environments/environment.dev';
import { JwtTokenInterceptorService } from './Auth/jwt-token-interceptor.service';
import { SearchComponent } from './phonebook/search/search.component';

export function getToken() {
  return localStorage.getItem('JwtToken');
}

@NgModule({
  declarations: [
    AppComponent,
    PhonebookComponent,
    AddEditEntryComponent,
    ViewPhonebookComponent,
    LoginComponent,
    ErrorPageComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        allowedDomains: [environment.apiBaseUrl + '/api'],
        disallowedRoutes: []
      }
    })
  ],
  providers: [ {provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptorService, multi: true},
     PhonebookApiService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
