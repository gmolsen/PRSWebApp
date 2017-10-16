import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequestLineItem } from '../models/PurchaseRequestLineItem';


import { PurchaseRequest } from '../models/PurchaseRequest';
import { Product } from '../models/Product';

//the URL's called from this service all have these elements
const urlBase = 'http://localhost:65241/';
const mvcCtrl = 'PurchaseRequestLineItems/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class PurchaseRequestLineItemService {

  constructor(private http: Http) { }

  list(): Promise<PurchaseRequestLineItem[]> {
  		return this.http.get(url+'List')
  			.toPromise()
  			.then(resp => resp.json() as PurchaseRequestLineItem[])
  			.catch(this.handleError);
  	} 

    review(): Promise<PurchaseRequestLineItem[]> {
      return this.http.get(url+'Review')
        .toPromise()
        .then(resp => resp.json() as PurchaseRequestLineItem[])
        .catch(this.handleError);
    } 

    get(id): Promise<PurchaseRequestLineItem> {
      return this.http.get(url+'Get/' + id)
      .toPromise()
      .then(resp => resp.json() as PurchaseRequestLineItem)
      .catch(this.handleError);
    }

    change(purchaserequestlineitem: PurchaseRequestLineItem): Promise<any>{
    // This function requires the purchaserequestlineitem to be passed in, so we can change it
      //Because we are making a change, just like when we use the Postman app,
      //we need to use "post" instead of "get"
      return this.http.post(url+'Change', purchaserequestlineitem)
      .toPromise()
      //The .then determines what a Promise returns, in this case, a specified product
      .then(resp => resp.json() || {})
      .catch(this.handleError);
  }

  add(purchaserequestlineitem: PurchaseRequestLineItem): Promise<any>{
      return this.http.post(url+'Add', purchaserequestlineitem)
      .toPromise()
      .then(resp => resp.json() || {})
      .catch(this.handleError);
  }

  remove(purchaserequestlineitem: PurchaseRequestLineItem): Promise<any>{
      return this.http.post(url+'Remove', purchaserequestlineitem)
      .toPromise()
      .then(resp => resp.json() || {})
      .catch(this.handleError);
  }

  	//generic error handling
  	private handleError(error:any): Promise<any> { //private functions and properties must be specified, public do not have to be specified
  		console.error('An error has occurred', error);
  		return Promise.reject(error.message || error);
  	}

}
