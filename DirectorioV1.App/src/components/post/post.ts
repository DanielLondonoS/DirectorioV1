import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

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
export class PostComponent implements OnInit {
  @Input() clienteDatos : any[] = [];
  @Output() onCall = new EventEmitter<any>();
  @Output() onDetail = new EventEmitter<any>();
  text:any =""
  constructor() {
    console.log({Funcion:'Hello PostComponent Component',clienteDatos:this.clienteDatos});
    
  }

  ngOnInit(){
    console.log({Funcion:' PostComponent ionViewDidLoad',clienteDatos:this.clienteDatos});

  }

  makeCall(cliente:any){
    this.onCall.emit(cliente);
  }

  viewDetail(cliente:any){
    console.log({funcion:'viewDetail',cliente:cliente})
    this.onDetail.emit(cliente);
  }

}
