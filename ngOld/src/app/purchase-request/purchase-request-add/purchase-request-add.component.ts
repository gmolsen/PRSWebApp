import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { SystemService } from '../../services/system.service';
import { PurchaseRequestService } from '../../services/purchase-request.service';
import { PurchaseRequest } from '../../models/PurchaseRequest';
import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-purchase-request-add',
  templateUrl: './purchase-request-add.component.html',
  styleUrls: ['./purchase-request-add.component.css']
})
export class PurchaseRequestAddComponent implements OnInit {

	purchaserequest: PurchaseRequest = new PurchaseRequest(0, '', '', '', new Date, new Date(Date.now() + 604800000), '', 'New', 0, 0);

	users: User[];
	
	loggedInUser: User;

	add() {
    this.purchaserequest.UserID = this.loggedInUser.UserID; 
		this.PurchaseRequestSvc.add(this.purchaserequest).then(
			resp => { 
				console.log(resp); 
				this.router.navigate(["/purchaserequests"]); 
			}
		);
	}

// 	getUsers(): void {
// 	this.UserSvc.list().then(
// 	resp => this.users = resp);
// }

  constructor(private PurchaseRequestSvc: PurchaseRequestService, 
  			private SystemSvc: SystemService,
  			private router: Router) { }

  ngOnInit() {
  	if(!this.SystemSvc.isLoggedIn()) {
  		this.router.navigateByUrl("/login");
  	} else {
  		this.loggedInUser = this.SystemSvc.getLoggedIn();
          //taking primary key from loggedInUser and stuffing it in foreign key of purchaserequest so that the ID
          //of the logged in user is always attached to the purchase request that is being created
  		this.purchaserequest.UserID = this.loggedInUser.UserID;
  	}
  }

}
