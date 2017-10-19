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
import { SystemService } from './services/system.service';
import { VendorService } from './services/vendor.service';
import { ProductService } from './services/product.service';
import { PurchaseRequestService } from './services/purchase-request.service';
import { PurchaseRequestLineItemService } from './services/purchase-request-line-item.service';

import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserAddComponent } from './user/user-add/user-add.component';

import { VendorListComponent } from './vendor/vendor-list/vendor-list.component';
import { VendorAddComponent } from './vendor/vendor-add/vendor-add.component';
import { VendorDetailComponent } from './vendor/vendor-detail/vendor-detail.component';
import { VendorEditComponent } from './vendor/vendor-edit/vendor-edit.component';

import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';

import { PurchaseRequestListComponent } from './purchase-request/purchase-request-list/purchase-request-list.component';
import { PurchaseRequestDetailComponent } from './purchase-request/purchase-request-detail/purchase-request-detail.component';
import { PurchaseRequestAddComponent } from './purchase-request/purchase-request-add/purchase-request-add.component';
import { PurchaseRequestEditComponent } from './purchase-request/purchase-request-edit/purchase-request-edit.component';
import { PurchaseRequestReviewComponent } from './purchase-request/purchase-request-review/purchase-request-review.component';

import { PurchaseRequestLineItemListComponent } from './purchase-request-line-item/purchase-request-line-item-list/purchase-request-line-item-list.component';
import { PurchaseRequestLineItemEditComponent } from './purchase-request-line-item/purchase-request-line-item-edit/purchase-request-line-item-edit.component';
import { PurchaseRequestLineItemAddComponent } from './purchase-request-line-item/purchase-request-line-item-add/purchase-request-line-item-add.component';

  //in Angular, everything with @ is a decorator - does not end with  ;
  //@NGModule is THE module for our application
@NgModule({ //everything inside this curly brace is a JS object

    //components must be added to declarations (automatically added if command line is used to add component)
  declarations: [ //key
    AppComponent,  //values
    MenuComponent, 
    HeadingComponent, 
    HomeComponent, 
    AboutComponent, 
    ContactComponent, 
    HelpComponent, 
    LoginComponent, 
    UserListComponent, 
    UserDetailComponent, 
    UserEditComponent, 
    UserAddComponent, 
    VendorListComponent, 
    VendorAddComponent, 
    VendorDetailComponent, 
    VendorEditComponent, 
    ProductListComponent, 
    ProductDetailComponent, 
    ProductAddComponent, 
    ProductEditComponent,
    PurchaseRequestListComponent, 
    PurchaseRequestDetailComponent, 
    PurchaseRequestAddComponent, 
    PurchaseRequestEditComponent, 
    PurchaseRequestReviewComponent, 
    PurchaseRequestLineItemListComponent, 
    //PurchaseRequestLineItemAddComponent, 
    PurchaseRequestLineItemEditComponent, 
    PurchaseRequestLineItemAddComponent, 
  ],

  imports: [//key
    BrowserModule, //values
    FormsModule,
    AppRoutingModule,
    HttpModule
  ],

  providers: [
    UserService,
    VendorService,
    ProductService,
    PurchaseRequestService,
    PurchaseRequestLineItemService,
    SystemService
  ],
    //one or more components that will start at run-time
  bootstrap: [AppComponent] 
})
  // export allows other components to use whatever it's modifying by using import modifier; always include on classes
export class AppModule { }
