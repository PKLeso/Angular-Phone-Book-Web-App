import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, observable } from 'rxjs';
import { PhonebookApiService } from 'src/app/Shared/phonebook-api.service';

@Component({
  selector: 'app-add-edit-entry',
  templateUrl: './add-edit-entry.component.html',
  styleUrls: ['./add-edit-entry.component.css']
})
export class AddEditEntryComponent implements OnInit {

  phonebookList$! : Observable<any[]>;
  entryList$!: Observable<any[]>;

  @Input() entry: any;
  Id: number = 0 ;
  Name: string = '';
  PhoneNumber: string = '';
  PhonebookId: number = 1;

  constructor(private apiService: PhonebookApiService) { }

  ngOnInit(): void {
    this.Id = this.entry.Id;
    this.Name = this.entry.Name;
    this.PhoneNumber = this.entry.Phonebook;
    this.PhonebookId = this.entry.PhonebookId;

    this.entryList$ = this.apiService.getEntryList();

  }


  AddPhonebooEntry() {
    this.apiService.addEntry(this.entry).subscribe(response => {
      var modalCloseBtn = document.getElementById('add-edit-model-close');
      if(modalCloseBtn) {
        modalCloseBtn.click();
      }

      var displaySuccessAlert = document.getElementById('add-success-alert');
      if(displaySuccessAlert){ displaySuccessAlert.style.display = "block"; }

      setTimeout(() => {
        if(displaySuccessAlert) { displaySuccessAlert.style.display = "none"; }
      }, 5000);

    }, err => {      
      var displayErrorAlert = document.getElementById('add-error-alert');      
      if(displayErrorAlert){ displayErrorAlert.style.display = "block"; }
      setTimeout(() => {
        if(displayErrorAlert) { displayErrorAlert.style.display = "none"; }
      }, 5000);
      console.log('See error: ', err); // use logs
    })

  }

  UpdatePhonebookEntry() {
    this.apiService.updateEntry(this.entry.id,this.entry).subscribe(response => {
      var modalCloseBtn = document.getElementById('add-edit-model-close');
      if(modalCloseBtn) {
        modalCloseBtn.click();
      }

      var displaySuccessAlert = document.getElementById('update-success-alert');
      if(displaySuccessAlert){ displaySuccessAlert.style.display = "block"; }
      
      setTimeout(() => {
        if(displaySuccessAlert) { displaySuccessAlert.style.display = "none"; }
      }, 5000);

    }, err => {      
      var displayErrorAlert = document.getElementById('error-alert');      
      if(displayErrorAlert){ displayErrorAlert.style.display = "block"; }
      setTimeout(() => {
        if(displayErrorAlert) { displayErrorAlert.style.display = "none"; }
      }, 5000);
      console.log('See error: ', err); // use logs
    })
  }
}
