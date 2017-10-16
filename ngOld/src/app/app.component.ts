import { Component } from '@angular/core';

@Component({
  selector: 'app-root', //can be named anything
  templateUrl: './app.component.html',
  //template: '<h1>Template</h1>',
  styleUrls: ['./app.component.css'] //an array of files with css styles in it
 // styles: ['h1 { color: blue }'] //css can also be done inline this way
})
// export is a modifier on a class that allows it to be used by other components by using import
export class AppComponent {
  scriptingLanguage = 'Typescript'
}
