import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/Product';
import { Vendor } from '../../models/Vendor';
import { VendorService } from '../../services/vendor.service';

@Component({

  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

	product: Product = new Product(0, '', '', 0, '', '', 0);

	vendors: Vendor[];
	
	add() {
		this.ProductSvc.add(this.product).then(
			resp => { 
				console.log(resp); 
				this.router.navigate(["/products"]); 
			}
		);
	}

	getVendors(): void {
	this.VendorSvc.list().then(
	resp => this.vendors = resp);
}

  constructor(private ProductSvc: ProductService, private VendorSvc: VendorService, private router: Router) { }

  ngOnInit() {
  		this.getVendors();
  }

}