import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaseRequestService } from '../../services/purchase-request.service';

import { User } from '../../models/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'purchase-request-list',
  templateUrl: './purchase-request-list.component.html',
  styleUrls: ['./purchase-request-list.component.css']
})
export class PurchaseRequestListComponent implements OnInit {

  purchaserequests: PurchaseRequest[];

  user: User;

  getPurchaseRequests(): void {
    console.log("About to get purchase requests");
    this.PurchaseRequestSvc.list()
      .then(resp => {
        console.log("List of purchase requests: ", resp);
        this.purchaserequests = resp
      });
  }

  constructor(private PurchaseRequestSvc: PurchaseRequestService) { }

  ngOnInit() { console.log("ngOnInIt");
    this.getPurchaseRequests();
  }
}