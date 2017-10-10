import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';
import { UserListComponent } from './user/user-list/user-list.component';

const routes: Routes = [ //routes define where to go based on the URL; const means variable will be set and never changed
		
	{ path: "", redirectTo: "/home", pathMatch: "full" }, //CATCH-ALL - redirect to homepage if URL invalid
	{ path: "home", component: HomeComponent }, //routes to each component, but stays on same page
	{ path: "login", component: LoginComponent },
	{ path: "users", component: UserListComponent },
	{ path: "about", component: AboutComponent },
	{ path: "contact", component: ContactComponent },
	{ path: "help", component: HelpComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
