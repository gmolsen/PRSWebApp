import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute, ParamMap} from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';


import {PurchaseRequest} from '../../models/PurchaseRequest';
import {PurchaseRequestService} from '../../services/purchase-request.service';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-purchase-request-edit',
  templateUrl: './purchase-request-edit.component.html',
  styleUrls: ['./purchase-request-edit.component.css']
})
export class PurchaseRequestEditComponent implements OnInit {

	purchaserequest:PurchaseRequest;
	users: User[];

	update(){
		this.PurchaseRequestSvc.change(this.purchaserequest).then(
			resp => {console.log(resp);
				this.router.navigate(['/purchaserequests'])}
		)
	}

  constructor(private PurchaseRequestSvc: PurchaseRequestService, private UserSvc: UserService, private route: ActivatedRoute, private router: Router) { }

  	getUsers(): void {
		this.UserSvc.list().then(
			resp => this.users = resp);
}

  ngOnInit() {
  	this.route.paramMap
  	 	.switchMap((params: ParamMap) =>
  	 		//params gets id out of URL and passes it into get function
  	 		this.PurchaseRequestSvc.get(params.get('id')))
  	 	//Subscribe reads the data currently held by PurchaseRequest, and stores it in the purchaserequest variable above
           .subscribe((purchaserequest: PurchaseRequest) => this.purchaserequest = purchaserequest);
 	
 	this.getUsers();
	}

}