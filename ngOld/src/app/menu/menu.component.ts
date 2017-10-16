import { Component, OnInit } from '@angular/core';

//imports menu.ts file
import { Menu } from './menu';

@Component({
  selector: 'menu-comp',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
//OnInit is sort of like inheritance in c#
export class MenuComponent implements OnInit {

	name = "Menu Component";

//creates an array of menu items and stores it inside variable menus
menus: Menu[] = [
	new Menu("HOME", "/home", "Home menu item"),
  new Menu("LOGIN ", "/login", "Login menu item"),
  new Menu("USERS ", "/users", "User list"),
  new Menu("VENDORS ", "/vendors", "Vendor list"),
  new Menu("PRODUCTS ", "/products", "Product list"),
  new Menu("PURCHASEREQUESTS ", "/purchaserequests", "Purchase Request list"),
  new Menu("REVIEW ", "/purchaserequests/review", "Review list"),
	new Menu("ABOUT", "/about", "About menu item"),
	new Menu("CONTACT", "/contact", "Contact menu item"),
	new Menu("HELP", "/help", "Help menu item")	
];

  constructor() { }

  ngOnInit() {
  }

}
