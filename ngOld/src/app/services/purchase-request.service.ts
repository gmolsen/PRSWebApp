import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
//import { Observable } from 'rxjs';

import { PurchaseRequest } from '../models/PurchaseRequest';


import { User } from '../models/User';

//the URL's called from this service all have these elements
const urlBase = 'http://localhost:65241/';
const mvcCtrl = 'PurchaseRequests/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class PurchaseRequestService {

  constructor(private http: Http) { }

  list(): Promise<PurchaseRequest[]> {
  		return this.http.get(url+'List')
  			.toPromise()
  			.then(resp => resp.json() as PurchaseRequest[])
  			.catch(this.handleError);
  	} 

    get(id): Promise<PurchaseRequest> {
      return this.http.get(url+'Get/' + id)
      .toPromise()
      .then(resp => resp.json() as PurchaseRequest)
      .catch(this.handleError);
    }

    change(purchaserequest: PurchaseRequest): Promise<any>{
    // This function requires the purchaserequest to be passed in, so we can change it
      //Because we are making a change, just like when we use the Postman app,
      //we need to use "post" instead of "get"
      return this.http.post(url+'Change', purchaserequest)
      .toPromise()
      //The .then determines what a Promise returns, in this case, a specified product
      .then(resp => resp.json() || {})
      .catch(this.handleError);
  }

  add(purchaserequest: PurchaseRequest): Promise<any>{
      return this.http.post(url+'Add', purchaserequest)
      .toPromise()
      .then(resp => resp.json() || {})
      .catch(this.handleError);
  }

  remove(purchaserequest: PurchaseRequest): Promise<any>{
      return this.http.post(url+'Remove', purchaserequest)
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
