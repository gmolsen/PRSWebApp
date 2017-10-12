import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/Product';

import { Vendor } from '../models/Vendor';

@Component({

  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

	product: Product = new Product(0, '', '', 0, '', '', 0, Vendor);
	
	add() {
		this.ProductSvc.add(this.product).then(
			resp => { 
				console.log(resp); 
				this.router.navigate(["/products"]); 
			}
		);
	}

  constructor(private ProductSvc: ProductService, private router: Router) { }

  ngOnInit() {
  }

}