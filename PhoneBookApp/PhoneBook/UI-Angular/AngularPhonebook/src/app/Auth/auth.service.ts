import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService) { }

  public getToken(): any {
    return localStorage.getItem('JwtToken');
  }

  
  public removeToken(): any {
    return localStorage.removeItem('JwtToken');
  }

  public setToken(token: any) {
    console.log('token: ', token);
      localStorage.setItem("JwtToken", token); // one can also use the session storage for the token
  }

  public refreshToken(){}

}