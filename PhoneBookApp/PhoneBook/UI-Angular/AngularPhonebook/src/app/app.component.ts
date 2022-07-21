import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './Auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Phonebook';


  constructor(private authService: AuthService,
    private jwtHelper: JwtHelperService){}

  
  public isAuthenticated(): boolean {    
    const token = this.authService.getToken();
    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    else {
      return false;
    }
  }

  logOut() {
    this.authService.removeToken();
  }
}
