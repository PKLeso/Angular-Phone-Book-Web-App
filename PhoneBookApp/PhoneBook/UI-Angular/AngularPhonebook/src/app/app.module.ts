import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PhonebookComponent } from './phonebook/phonebook.component';
import { AddEditEntryComponent } from './phonebook/add-edit-entry/add-edit-entry.component';
import { ViewPhonebookComponent } from './phonebook/view-phonebook/view-phonebook.component';
import { PhonebookApiService } from './Shared/phonebook-api.service'

@NgModule({
  declarations: [
    AppComponent,
    PhonebookComponent,
    AddEditEntryComponent,
    ViewPhonebookComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [PhonebookApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
