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
  selector: 'purchase-request-line-item-list',
  templateUrl: './purchase-request-line-item-list.component.html',
  styleUrls: ['./purchase-request-line-item-list.component.css']
})
export class PurchaseRequestLineItemListComponent implements OnInit {

  purchaserequestandlines: PurchaseRequestAndLines;

  purchaserequestlineitems: PurchaseRequestLineItem[];

    //creates instance of PurchaseRequestLineItem to be used below by the remove function
  purchaserequestlineitem: PurchaseRequestLineItem = new PurchaseRequestLineItem(0, 0, 0, 1);

  purchaserequest: PurchaseRequest;

  // getPurchaseRequestLineItems(): void {
  //   console.log("About to get purchase requests");
  //   this.PurchaseRequestLineItemSvc.list()
  //     .then(resp => {
  //       console.log("List of purchase requests: ", resp);
  //       this.purchaserequestlineitems = resp
  //     });
  // }

    //PurchaseRequestLineItemID is passed in from HTML as a parameter of the remove() function
  remove(id) {
    this.purchaserequestlineitem.PurchaseRequestLineItemID = id;
    this.PurchaseRequestLineItemSvc.remove(this.purchaserequestlineitem)
      .then(resp => { 
        console.log(resp); 
        this.router.navigate(["/purchaserequests"]); 
      });
  }

  accept() {
    this.purchaserequestandlines.PurchaseRequest.Status = "ACCEPTED"
    console.log(this.purchaserequestandlines.PurchaseRequest)
    this.PurchaseRequestSvc.change(this.purchaserequestandlines.PurchaseRequest)
      .then(resp => { 
        console.log(resp); 
        this.router.navigate(["/purchaserequests"]); 
      });
  }

    reject() {
    console.log("reject");
    this.purchaserequestandlines.PurchaseRequest.Status = "REJECTED"
    console.log(this.purchaserequestandlines.PurchaseRequest)
    this.PurchaseRequestSvc.change(this.purchaserequestandlines.PurchaseRequest)
      .then(resp => { 
        console.log(resp); 
        this.router.navigate(["/purchaserequests"]); 
      });
  }

  constructor(private PurchaseRequestSvc: PurchaseRequestService,
    private PurchaseRequestLineItemSvc: PurchaseRequestLineItemService,
     private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() { console.log("ngOnInIt");

  this.route.paramMap
       .switchMap((params: ParamMap) =>
           //params gets id out of URL and passes it into getByPurchaseRequestID function
         this.PurchaseRequestLineItemSvc.getByPurchaseRequestId(params.get('id')))
       //Subscribe reads the data currently held by PurchaseRequest, and stores it in the purchaserequest variable above
           .subscribe((purchaserequestandlines: PurchaseRequestAndLines) => this.purchaserequestandlines = purchaserequestandlines);

    // this.getPurchaseRequestLineItems();
  }
}