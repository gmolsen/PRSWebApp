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

}
