import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Vendor } from '../../models/Vendor';
import { VendorService } from '../../services/vendor.service';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
  styleUrls: ['./vendor-detail.component.css']
})
export class VendorDetailComponent implements OnInit {

	vendor: Vendor;

	remove() {
		console.log("remove()");
		this.VendorSvc.remove(this.vendor)
			.then(resp => { 
				console.log(resp); 
				this.router.navigate(["/vendors"]); 
			});
	}

  constructor(private VendorSvc: VendorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
		this.route.paramMap
			.switchMap((params: ParamMap) =>
				this.VendorSvc.get(params.get('id')))
			.subscribe((vendor: Vendor) => this.vendor = vendor);  
	}

}

