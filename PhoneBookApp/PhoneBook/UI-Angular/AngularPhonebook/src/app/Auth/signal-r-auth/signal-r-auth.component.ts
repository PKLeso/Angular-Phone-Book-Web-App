import { Component, OnDestroy, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { User } from 'src/app/Shared/models/user-model';
import { SignalrService } from 'src/app/Shared/signalr.service';

@Component({
  selector: 'app-signal-r-auth',
  templateUrl: './signal-r-auth.component.html',
  styleUrls: ['./signal-r-auth.component.css']
})
export class SignalRAuthComponent implements OnInit, OnDestroy {

  constructor(public signalrService: SignalrService) { }

  users: Array<User> = new Array<User>();

  ngOnInit(): void {
    this.signalrService.chatAuthListenerSuccess();
    this.signalrService.chatAuthFailResponse();

    this.userOnListener();
    this.userOfListener();
    this.getOnlineUsersListener();

    if (this.signalrService.hubConnection$?.state === signalR.HubConnectionState.Connected){
      this.getOnlineUsers();
    }
    else {
      this.signalrService.signalrSubject.subscribe((subj: any) => {
        if(subj.type == "HubConnStarted") {
          this.getOnlineUsers();
        }
      });
    }
  }

  ngOnDestroy(): void {
    this,this.signalrService.hubConnection$.off("chatAuthSuccessResponse");
    this,this.signalrService.hubConnection$.off("chatAuthFailResponse");
  }

  
  userOnListener(): void {
    this.signalrService.hubConnection$.on("UserOn", (newUser: User) => {
      console.log(newUser);
      this.users.push(newUser);
    });
  }
  userOfListener(): void {
    this.signalrService.hubConnection$.on("UserOff", (userId: string) => {
      this.users = this.users.filter(f => f.id != userId);
    });
  }

  getOnlineUsers(): void {
    this.signalrService.hubConnection$.invoke("GetOnlineUsers")
    .catch(err => console.error(err));
  }
  getOnlineUsersListener() {
    this.signalrService.hubConnection$.on("GetOnlineUsersResponse", (onlineUsers: Array<User>) => {
      this.users = [...onlineUsers];
    })
  }

  // getOnlineUsersInv(): void {
  //   this.signalrService.hubConnection$.invoke("GetOnlineUsers")
  //   .catch(err => console.log(err));
  // }

}
