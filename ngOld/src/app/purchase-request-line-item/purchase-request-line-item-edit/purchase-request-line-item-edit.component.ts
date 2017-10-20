import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { SystemService } from '../../services/system.service';

import { PurchaseRequestAndLines } from '../../models/PurchaseRequestAndLines';

import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';
import { PurchaseRequestLineItemService } from '../../services/purchase-request-line-item.service';


import {PurchaseRequest} from '../../models/PurchaseRequest';
import {PurchaseRequestService} from '../../services/purchase-request.service';

import { Product } from '../../models/Product';
import { ProductService } from '../../services/product.service';

import { User } from '../../models/User';


@Component({
  selector: 'app-purchase-request-line-item-edit',
  templateUrl: './purchase-request-line-item-edit.component.html',
  styleUrls: ['./purchase-request-line-item-edit.component.css']
})
export class PurchaseRequestLineItemEditComponent implements OnInit {

	purchaserequestlineitem: PurchaseRequestLineItem;
  purchaserequest: PurchaseRequest;
	products: Product[];

	update(){
    // this.purchaserequest.PurchaseRequestID = this.purchaserequestlineitem.PurchaseRequestID
		this.PurchaseRequestLineItemSvc.change(this.purchaserequestlineitem).then(
			resp => {console.log(resp);
				this.router.navigateByUrl("/purchaserequestlineitems/GetByPurchaseRequestID/"
          +this.purchaserequestlineitem.PurchaseRequestID);
        // this.router.navigateByUrl("/purchaserequestlineitems/GetByPurchaseRequestID/"
        //   +this.purchaserequestlineitem.PurchaseRequestID);
		});
  };

  constructor(private PurchaseRequestLineItemSvc: PurchaseRequestLineItemService,
  private ProductSvc: ProductService,
  private PurchaseRequestSvc: PurchaseRequestService,
  private route: ActivatedRoute, 
  private router: Router) { }

  getProducts(): void {
		this.ProductSvc.list().then(
			resp => this.products = resp);
}

  ngOnInit() {
  	this.route.paramMap
  	 	.switchMap((params: ParamMap) =>
  	 		//params gets id out of URL and passes it into get function
  	 		this.PurchaseRequestLineItemSvc.get(params.get('id')))
  	 	//Subscribe reads the data currently held by PurchaseRequestLineItem, and stores it in the purchaserequestlineitem variable above
           .subscribe((purchaserequestlineitem: PurchaseRequestLineItem) => this.purchaserequestlineitem = purchaserequestlineitem);
 	
 	this.getProducts();
	}
}
