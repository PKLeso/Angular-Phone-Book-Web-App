import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PhonebookApiService } from 'src/app/Shared/phonebook-api.service';

@Component({
  selector: 'app-view-phonebook',
  templateUrl: './view-phonebook.component.html',
  styleUrls: ['./view-phonebook.component.css']
})
export class ViewPhonebookComponent implements OnInit {

  entryList$!: Observable<any[]>;
  phonebookEntrylist$!: Observable<any>[]; 

  modalTitle: string = '';
  addEditEntryActivated: boolean = false;
  entry: any;

  
  //Display data associated with foregnKey
  phonebookEntriesMap:Map<number, string> = new Map();

  constructor(private apiService: PhonebookApiService) { }

  ngOnInit(): void {
    this.entryList$ = this.apiService.getEntryList();
  }

  
  modalClose() {
    this.addEditEntryActivated = false;
    this.entryList$ = this.apiService.getEntryList();
  }

  AddEntry() {
    this.entry = {
      Id:0,
      Name: null,
      PhoneNumber: null,
      PhonebookId: null
    }
    this.modalTitle = "Add Phonebook Entry";
    this.addEditEntryActivated = true;
  }

  editModal(entry:any) {
    this.entry = entry;
    this.addEditEntryActivated = true;

  }

  deleteEntry(entry: any){
    if(confirm(`Are you sure you want to delete phonebook entry ${entry.id}`)) {
      this.apiService.deleteEntry(entry.id).subscribe(response => {

        var displaySuccessAlert = document.getElementById('delete-success-alert');
        if(displaySuccessAlert){ displaySuccessAlert.style.display = "block"; }
  
        setTimeout(() => {
          if(displaySuccessAlert) { displaySuccessAlert.style.display = "none"; }
        }, 5000);
        this.entryList$ = this.apiService.getEntryList();

      }, err => {      
        var displayErrorAlert = document.getElementById('error-alert');      
        if(displayErrorAlert){ displayErrorAlert.style.display = "block"; }
        setTimeout(() => {
          if(displayErrorAlert) { displayErrorAlert.style.display = "none"; }
        }, 5000);
        console.log('See error: ', err); // use logs
      });


    }
  }

  }