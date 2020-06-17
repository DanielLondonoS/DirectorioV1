import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  @Input() clienteDatos : any[] = [];
  @Output() onCall = new EventEmitter<any>();
  @Output() onDetail = new EventEmitter<any>();
  @Output() onGeoClick = new EventEmitter<any>();

  constructor() {
    console.log({constructor:'PostComponent',clientDatos:this.clienteDatos})
   }

  ngOnInit() {}

  makeCall(cliente:any){
    this.onCall.emit(cliente);
  }

  viewDetail(cliente:any){
    console.log({funcion:'viewDetail',cliente:cliente})
    this.onDetail.emit(cliente);
  }

  geoClick(cliente:any){
    this.onGeoClick.emit(cliente);
  }

  
}
