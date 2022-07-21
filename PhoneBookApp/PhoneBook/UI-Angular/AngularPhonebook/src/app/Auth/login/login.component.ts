import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PhonebookApiService } from 'src/app/Shared/phonebook-api.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean = false;

  constructor(private router: Router, 
    private apiService: PhonebookApiService,
    private authService: AuthService) { }

  login(form: NgForm) {
    const userCredentials = {
      'username': form.value.username,
      'password': form.value.password
    }
    console.log('user credentials: ', userCredentials);
    this.apiService.login(userCredentials).subscribe(response => {
      this.authService.setToken((<any> response).token);
      this.invalidLogin = false;
      this.router.navigate(['/phonebook']);
    }, err => {  
      var displayErrorAlert = document.getElementById('login-error-alert');      
      if(displayErrorAlert){ displayErrorAlert.style.display = "block"; }
      setTimeout(() => {
        if(displayErrorAlert) { displayErrorAlert.style.display = "none"; }
      }, 5000);
      
      this.invalidLogin = true;  
      console.log('See error: ', err); // use logs  
    })
  }

}
