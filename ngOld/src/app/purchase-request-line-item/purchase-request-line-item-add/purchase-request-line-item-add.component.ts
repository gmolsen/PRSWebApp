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
  selector: 'app-purchase-request-line-item-add',
  templateUrl: './purchase-request-line-item-add.component.html',
  styleUrls: ['./purchase-request-line-item-add.component.css']
})
export class PurchaseRequestLineItemAddComponent implements OnInit {

	purchaserequestlineitem: PurchaseRequestLineItem = new PurchaseRequestLineItem(0, 0, 0, 1);
	
	purchaserequest: PurchaseRequest;

	loggedInUser: User;
	
	products: Product[];

	getProducts(): void {
		this.ProductSvc.list()
			.then(resp => this.products = resp);
	}

	add() {
		this.purchaserequestlineitem.PurchaseRequestID = this.purchaserequest.PurchaseRequestID;
		this.PurchaseRequestLineItemSvc.add(this.purchaserequestlineitem).then(
			resp => { 
				console.log(resp); 
				this.router.navigateByUrl("/purchaserequestlineitems/GetByPurchaseRequestID/"
					+this.purchaserequest.PurchaseRequestID); 
			}
		);
	}
	

  constructor(private PurchaseRequestSvc: PurchaseRequestService,
  	private PurchaseRequestLineItemSvc: PurchaseRequestLineItemService,
  	private ProductSvc: ProductService,
  	private SystemSvc: SystemService,
  	private route: ActivatedRoute,
  	private router: Router,
  	) { }

    ngOnInit() {
  	this.route.paramMap
  	 	.switchMap((params: ParamMap) =>
  	 			//params gets id out of URL and passes it into get function
  	 		this.PurchaseRequestSvc.get(params.get('id')))
  	 			//Subscribe reads the data currently held by PurchaseRequest, and stores it in the purchaserequest variable above
           .subscribe((purchaserequest: PurchaseRequest) => this.purchaserequest = purchaserequest);

	this.getProducts();
	}
}
