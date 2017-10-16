import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { User } from '../../models/User';

@Component({

  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

	user: User = new User(0, '', 'pass@word1!', '', '', '', '', false, false);
	
	add() {
		this.UserSvc.add(this.user).then(
			resp => { 
				console.log(resp); 
				this.router.navigate(["/users"]); 
			}
		);
	}

  constructor(private UserSvc: UserService, private router: Router) { }

  ngOnInit() {
  }

}