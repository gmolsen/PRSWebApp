import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaseRequestService } from '../../services/purchase-request.service';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-purchase-request-detail',
  templateUrl: './purchase-request-detail.component.html',
  styleUrls: ['./purchase-request-detail.component.css']
})
export class PurchaseRequestDetailComponent implements OnInit {

	purchaserequest: PurchaseRequest;

	user: User;

	remove() {
		console.log("remove()");
		this.PurchaseRequestSvc.remove(this.purchaserequest)
			.then(resp => { 
				console.log(resp); 
				this.router.navigate(["/purchaserequests"]); 
			});
	}

	review() {
		console.log("review()");
		if (this.purchaserequest.Total < 50) {
			this.purchaserequest.Status = "ACCEPTED"
		} else {
		this.purchaserequest.Status = "Review"
		}
		this.PurchaseRequestSvc.change(this.purchaserequest)
			.then(resp => { 
				console.log(resp); 
				this.router.navigate(["/purchaserequests"]); 
			});
	}

  constructor(private PurchaseRequestSvc: PurchaseRequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
  		console.log("PR-DETAIL", "ngOnInit()");
		this.route.paramMap
			.switchMap((params: ParamMap) =>
				this.PurchaseRequestSvc.get(params.get('id')))
			.subscribe((purchaserequest: PurchaseRequest) => this.purchaserequest = purchaserequest);  
		console.log(this.purchaserequest);
	}

}
