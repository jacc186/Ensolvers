import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodoListComponent } from './todo-list/todo-list.component';
import { SharedService } from './shared.service';
import {HttpClientModule} from '@angular/common/http';
import { ShowComponent } from './todo-list/show/show.component';
import { EditComponent } from './todo-list/edit/edit.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AppComponent,
    TodoListComponent,
    ShowComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
