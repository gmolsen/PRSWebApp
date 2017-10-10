  //you can kind of think of the module as the applicaiton, or the project in VS.net
  //the module needs to know about all the parts of the application

  //curly braces contain classes that we want to use for this module
  //@________ contains file where we can find class
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
  //module included with Angular that allows AJAX calls to be made 
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
  // ./ means file is in same directory as current file
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HeadingComponent } from './heading/heading.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';

import { UserService } from './services/user.service';
import { UserListComponent } from './user/user-list/user-list.component';

  //in Angular, everything with @ is a decorator - does not end with  ;
  //@NGModule is THE module for our application
@NgModule({ //everything inside this curly brace is a JS object

    //components must be added to declarations (automatically added if command line is used to add component)
  declarations: [ //key
    AppComponent,  //values
    MenuComponent, HeadingComponent, HomeComponent, AboutComponent, ContactComponent, HelpComponent, LoginComponent, UserListComponent
  ],

  imports: [//key
    BrowserModule, //values
    FormsModule,
    AppRoutingModule,
    HttpModule
  ],

  providers: [
    UserService],
    //one or more components that will start at run-time
  bootstrap: [AppComponent] 
})
  // export allows other components to use whatever it's modifying by using import modifier; always include on classes
export class AppModule { }
