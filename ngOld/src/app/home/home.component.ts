import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SystemService } from '../services/system.service';
import { User } from '../models/User';

@Component({ //one component per page; page = component
  selector: 'app-home',//made up HTML tag that allows you to put this component inside another
  templateUrl: './home.component.html',
  // template: "<h1 *ngIf='loggedInUser'>{{loggedInUser.UserName}}</h1>",
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loggedInUser: User;

  constructor(private SystemSvc: SystemService, private router: Router) { }

  ngOnInit() { //one time thing that happens inside component
  	//login authentication (will create system service)
  	if(!this.SystemSvc.isLoggedIn()) {
  		this.router.navigateByUrl("/login");
  	}
  	this.loggedInUser = this.SystemSvc.getLoggedIn();
  }

}
