import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute, ParamMap} from '@angular/router';
import { Observable } from 'rxjs/Observable';

import {Product} from '../../models/Product';
import {ProductService} from '../../services/product.service';

import { Vendor } from '../../models/Vendor';
import { VendorService } from '../../services/vendor.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

	product:Product;
	vendors: Vendor[];

	update(){
		this.ProductSvc.change(this.product).then(
			resp => {console.log(resp);
				this.router.navigate(['/products'])}
		)
	}

  constructor(private ProductSvc: ProductService, private VendorSvc: VendorService, private route: ActivatedRoute, private router: Router) { }

  	getVendors(): void {
		this.VendorSvc.list().then(
			resp => this.vendors = resp);
}

  ngOnInit() {
  	this.route.paramMap
  	 	.switchMap((params: ParamMap) =>
  	 		this.ProductSvc.get(params.get('id')))
  	 	//Subscribe reads the data currently held by Product, and stores it in the product variable above
           .subscribe((product: Product) => this.product = product);
 	
 	this.getVendors();
	}

}