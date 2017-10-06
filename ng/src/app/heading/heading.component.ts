import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'heading-comp',
  templateUrl: './heading.component.html',
  styleUrls: ['./heading.component.css']
})
export class HeadingComponent implements OnInit {

	name = '.Net Bootcamp'

  constructor() { }

  ngOnInit() {
  }

}
