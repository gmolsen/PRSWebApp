import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
//import { NgForm } from '@angular/forms';

import { User } from '../models/User';

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

	login(): void {
		let parms = "UserName=" + this.username + "&Password=" + this.password;
		//makes call to server and passes in data (this is how we make an ajax call)
		this.http.get("http://localhost:65241/Users/Login?" + parms)
			.subscribe(data => { this.checkData(data);
			});
	}

	checkData(data: any) : void {
		//console.log(data)
		if(data.text().length == 0)
			console.log("NO DATA");
		else {
			console.log(data.json());
			this.user = data.json();
		}
	}

  //injecting module we want to use into our component at run-time
  constructor(private http: Http) { }

  ngOnInit() {
  	// this.http.get("http://localhost:65241/Users/Login?UserName=user&Password=user")
  	// 	.subscribe(data => { console.log(data.json()); });
  }

}
