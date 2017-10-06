//curly braces contain classes that we want to use for this module
//@________ contains file where we can find class
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// ./ means file is in same directory as current file
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HeadingComponent } from './heading/heading.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';

//in Angular, everything with @ is a decorator - does not end with  ;
//@NGModule is THE module for our application
@NgModule({ //everything inside this curly brace is a JS object
  declarations: [ //key
    AppComponent, 
    MenuComponent, HeadingComponent, HomeComponent, AboutComponent, ContactComponent, HelpComponent
  ],
  imports: [//key
    BrowserModule, //value
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent] //component that will start at run-time
})
// export allows other components to use whatever it's modifying by using import modifier; always include on classes
export class AppModule { }
