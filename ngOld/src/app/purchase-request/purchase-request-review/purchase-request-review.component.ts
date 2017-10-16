import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaseRequestService } from '../../services/purchase-request.service';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'purchase-request-review',
  templateUrl: './purchase-request-review.component.html',
  styleUrls: ['./purchase-request-review.component.css']
})
export class PurchaseRequestReviewComponent implements OnInit {

  purchaserequests: PurchaseRequest[];

  user: User;

  getReviews(): void {
    console.log("About to get purchase requests needing review");
    this.PurchaseRequestSvc.review()
      .then(resp => {
        console.log("List of purchase requests needing review: ", resp);
        this.purchaserequests = resp
      });
  }

  constructor(private PurchaseRequestSvc: PurchaseRequestService) { }

  ngOnInit() { console.log("ngOnInIt");
    this.getReviews();
  }
}