import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Product } from '../../models/Product';
import { ProductService } from '../../services/product.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

	product: Product;

	remove() {
		console.log("remove()");
		this.ProductSvc.remove(this.product)
			.then(resp => { 
				console.log(resp); 
				this.router.navigate(["/products"]); 
			});
	}

  constructor(private ProductSvc: ProductService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
		this.route.paramMap
			.switchMap((params: ParamMap) =>
				this.ProductSvc.get(params.get('id')))
			.subscribe((product: Product) => this.product = product);  
	}

}
