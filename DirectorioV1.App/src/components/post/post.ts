import { Component, Input } from '@angular/core';

/**
 * Generated class for the PostComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'post',
  templateUrl: 'post.html'
})
export class PostComponent {
  @Input() clienteDatos : any;

  constructor() {
    console.log('Hello PostComponent Component');
    this.text = 'Hello World';
  }

}
