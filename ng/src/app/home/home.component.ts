import { Component, OnInit } from '@angular/core';

@Component({ //one component per page; page = component
  selector: 'app-home',//made up HTML tag that allows you to put this component inside another
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() { //one time thing that happens inside component
  }

}
