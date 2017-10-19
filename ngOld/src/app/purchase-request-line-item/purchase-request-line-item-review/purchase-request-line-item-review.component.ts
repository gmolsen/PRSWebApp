import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';

import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { PurchaseRequestLineItemService } from '../../services/purchase-request-line-item.service';

import { PurchaseRequest } from '../../models/PurchaseRequest';
import { PurchaseRequestService } from '../../services/purchase-request.service';

import { Product } from '../../models/Product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-purchase-request-line-item-review',
  templateUrl: './purchase-request-line-item-review.component.html',
  styleUrls: ['./purchase-request-line-item-review.component.css']
})
export class PurchaseRequestLineItemReviewComponent implements OnInit {

  purchaserequestandlines: PurchaseRequestAndLines;

  purchaserequestlineitems: PurchaseRequestLineItem[];

    //creates instance of PurchaseRequestLineItem to be used below by the remove function
  purchaserequestlineitem: PurchaseRequestLineItem = new PurchaseRequestLineItem(0, 0, 0, 1);

  purchaserequest: PurchaseRequest;

   accept() {
    this.purchaserequestandlines.PurchaseRequest.Status = "ACCEPTED"
    console.log(this.purchaserequestandlines.PurchaseRequest)
    this.PurchaseRequestSvc.change(this.purchaserequestandlines.PurchaseRequest)
      .then(resp => { 
        console.log(resp); 
        this.router.navigate(["/purchaserequests/review/"]); 
      });
  }

    reject() {
    console.log("reject");
    this.purchaserequestandlines.PurchaseRequest.Status = "REJECTED"
    console.log(this.purchaserequestandlines.PurchaseRequest)
    this.PurchaseRequestSvc.change(this.purchaserequestandlines.PurchaseRequest)
      .then(resp => { 
        console.log(resp); 
        this.router.navigate(["/purchaserequests/review/"]); 
      });
  }

  constructor(private PurchaseRequestSvc: PurchaseRequestService,
  	private PurchaseRequestLineItemSvc: PurchaseRequestLineItemService,
  	private router: Router,
  	private route: ActivatedRoute) { }

  ngOnInit() {

  	this.route.paramMap
       .switchMap((params: ParamMap) =>
           //params gets id out of URL and passes it into getByPurchaseRequestID function
         this.PurchaseRequestLineItemSvc.getByPurchaseRequestId(params.get('id')))
       //Subscribe reads the data currently held by PurchaseRequest, and stores it in the purchaserequest variable above
           .subscribe((purchaserequestandlines: PurchaseRequestAndLines) => this.purchaserequestandlines = purchaserequestandlines);
  }

}
