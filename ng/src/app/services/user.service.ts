import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';

import { User } from '../models/User';

//the URL's called from this service all have these elements
const urlBase = 'http://localhost:65241/';
const mvcCtrl = 'Users/';
const url: string = urlBase + mvcCtrl;

@Injectable()
export class UserService {

  constructor(private http: Http) { }

  	login(username: string, password: string): Promise<User[]> {
  		let parms = "UserName=" + username + "&Password=" + password;
  		return this.http.get(url+'Login?'+parms)
  			.toPromise()
  			.then(resp => resp.json() as User[])
  			.catch(this.handleError);
  	}
  	//generic error handling
  	private handleError(error:any): Promise<any> { //private functions and properties must be specified, public do not have to be specified
  		console.error('An error has occurred', error);
  		return Promise.reject(error.message || error);
  	}

}
