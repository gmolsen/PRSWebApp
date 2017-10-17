import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

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

  product: Product;

  purchaserequest: PurchaseRequest;

  getPurchaseRequestLineItems(): void {
    console.log("About to get purchase requests");
    this.PurchaseRequestLineItemSvc.list()
      .then(resp => {
        console.log("List of purchase requests: ", resp);
        this.purchaserequestlineitems = resp
      });
  }

  constructor(private PurchaseRequestLineItemSvc: PurchaseRequestLineItemService) { }

  ngOnInit() { console.log("ngOnInIt");

  this.route.paramMap
       .switchMap((params: ParamMap) =>
         this.PurchaseRequestLineItemSvc.get(params.get('id')))
       //Subscribe reads the data currently held by PurchaseRequest, and stores it in the purchaserequest variable above
           .subscribe((purchaserequest: PurchaseRequest) => this.purchaserequestandlines = purchaserequestandlines);

    this.getPurchaseRequestLineItems();
  }
}