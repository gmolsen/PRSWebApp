import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';

import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserAddComponent } from './user/user-add/user-add.component';

import { VendorListComponent } from './vendor/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './vendor/vendor-detail/vendor-detail.component';
import { VendorAddComponent } from './vendor/vendor-add/vendor-add.component';
import { VendorEditComponent } from './vendor/vendor-edit/vendor-edit.component';

import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';

import { PurchaseRequestListComponent } from './purchase-request/purchase-request-list/purchase-request-list.component';
import { PurchaseRequestDetailComponent } from './purchase-request/purchase-request-detail/purchase-request-detail.component';
import { PurchaseRequestAddComponent } from './purchase-request/purchase-request-add/purchase-request-add.component';
import { PurchaseRequestEditComponent } from './purchase-request/purchase-request-edit/purchase-request-edit.component';




const routes: Routes = [ //routes define where to go based on the URL; const means variable will be set and never changed
		
	{ path: "", redirectTo: "/home", pathMatch: "full" }, //CATCH-ALL - redirect to homepage if URL invalid
	{ path: "home", component: HomeComponent }, //routes to each component, but stays on same page
	{ path: "login", component: LoginComponent },
	{ path: "users", component: UserListComponent },
	{ path: "users/detail/:id", component: UserDetailComponent },
	{ path: "users/edit/:id", component: UserEditComponent },
	{ path: "users/add", component: UserAddComponent },

	{ path: "vendors", component: VendorListComponent },
	{ path: "vendors/detail/:id", component: VendorDetailComponent },
	{ path: "vendors/edit/:id", component: VendorEditComponent },
	{ path: "vendors/add", component: VendorAddComponent }, 
	
	{ path: "products", component: ProductListComponent },
	{ path: "products/detail/:id", component: ProductDetailComponent },
	{ path: "products/edit/:id", component: ProductEditComponent },
	{ path: "products/add", component: ProductAddComponent },

	{ path: "purchaserequests", component: PurchaseRequestListComponent },
	{ path: "purchaserequests/detail/:id", component: PurchaseRequestDetailComponent },
	{ path: "purchaserequests/edit/:id", component: PurchaseRequestEditComponent },
	{ path: "purchaserequests/add", component: PurchaseRequestAddComponent },

	{ path: "about", component: AboutComponent },
	{ path: "contact", component: ContactComponent },
	{ path: "help", component: HelpComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
