import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/ToPromise';

import { User } from '../models/User';
import { UserService } from '../services/user.service';
	// import { SystemService } from '../services/system.service';

	//decorators are not javascript syntax
@Component({
	//selector gets stuffed into html tag where we want component to be; requires hyphen
  selector: 'app-login',
  	//
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
	//must be exported because every component is used by something else
export class LoginComponent implements OnInit {

	username: string = "";
	password: string = "";

	user: User;

	message: string = " ";

	login(): void {
		this.message = "";
		this.UserSvc.login(this.username, this.password)
			.then(resp => this.checkData(resp));
	}

	checkData(users: User[]) : void {
		if(users.length > 0) {
			// this.user = users[0];
			// this.SystemSvc.LoggedInUser = this.user;
			// console.log("Set SystemSvc logged in user to ", this.SystemSvc.LoggedInUse);
			this.router.navigateByUrl("/home");
		}
		else {
			this.message = "USER NAME AND/OR PASSWORD NOT FOUND";
		}
	}

  //injecting module we want to use into our component at run-time
  constructor(private UserSvc: UserService, private router: Router) { }

  ngOnInit() {
  	// this.http.get("http://localhost:65241/Users/Login?UserName=user&Password=user")
  	// 	.subscribe(data => { console.log(data.json()); });
  }

}
