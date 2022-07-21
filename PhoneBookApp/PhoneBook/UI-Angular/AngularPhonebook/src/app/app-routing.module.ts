import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Auth/guards/auth-guard.service';
import { LoginComponent } from './Auth/login/login.component';
import { PhonebookComponent } from './phonebook/phonebook.component';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'phonebook', component:PhonebookComponent, canActivate: [AuthGuard]},
  {path: '**', component: ErrorPageComponent} // must always be last.
]

@NgModule({
  declarations: [],
  imports: [
    [RouterModule.forRoot(routes)]
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
