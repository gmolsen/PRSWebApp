import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

	users: User[];

	getUsers(): void {
		this.UserSvc.list()
			.then(resp => this.users = resp);
	}

  constructor(private UserSvc: UserService) { }

  	//UserListComponent calls this function first
  ngOnInit() {
  	this.getUsers();
  }

}
