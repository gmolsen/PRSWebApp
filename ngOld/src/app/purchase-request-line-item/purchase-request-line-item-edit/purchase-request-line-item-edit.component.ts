import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { PurchaseRequestLineItem } from '../../models/PurchaseRequestLineItem';


import {PurchaseRequest} from '../../models/PurchaseRequest';
import {PurchaseRequestService} from '../../services/purchase-request.service';

import { Product } from '../../models/Product';
import { ProductService } from '../../services/product.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-purchase-request-line-item-edit',
  templateUrl: './purchase-request-line-item-edit.component.html',
  styleUrls: ['./purchase-request-line-item-edit.component.css']
})
export class PurchaseRequestLineItemEditComponent implements OnInit {

	purchaserequest:PurchaseRequest;
	products: Product[];

	update(){
		this.PurchaseRequestSvc.change(this.purchaserequest).then(
			resp => {console.log(resp);
				this.router.navigate(['/purchaserequests'])}
		)
	}

  constructor(private PurchaseRequestSvc: PurchaseRequestService, private ProductSvc: ProductService, private route: ActivatedRoute, private router: Router) { }

  getProducts(): void {
		this.ProductSvc.list().then(
			resp => this.products = resp);
}

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
