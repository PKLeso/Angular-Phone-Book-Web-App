import { Component, OnDestroy, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './Auth/auth.service';
import { SignalrAuthService } from './Auth/signal-r-auth/signalr-auth.service';
import { User } from './Shared/models/user-model';
import { SignalrService } from './Shared/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit, OnDestroy{
  title = 'Phonebook App';


  constructor(private authService: AuthService,
    private jwtHelper: JwtHelperService,
    public signalrService: SignalrService,
    public signalrAuthService: SignalrAuthService){}

  ngOnInit(): void {
    this.signalrService.startConnection();

    this.logoutListener();
  }

  ngOnDestroy(): void {
    this.signalrService.hubConnection$.off("ChatAuthSuccessResponse");
  }

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
    // signal r
    this.signalrService.hubConnection$.invoke("Logout", this.signalrService.userData$.id)
    .catch(err => console.error(err));
    this.isAuthenticated();
  }

  // logout listener
  logoutListener(): void {
    this.signalrService.hubConnection$.on("LogoutResponse", () => {
      localStorage.removeItem("userId");
      location.reload();
    })
  }

  // userOnListener(): void {
  //   this.signalrService.hubConnection$.on("UserOn", (newUser: User) => {
  //     console.log(newUser);
  //     this.us
  //   })
  // }
}
