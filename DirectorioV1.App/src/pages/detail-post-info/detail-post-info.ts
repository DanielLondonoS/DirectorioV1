import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the DetailPostInfoPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-detail-post-info',
  templateUrl: 'detail-post-info.html',
})
export class DetailPostInfoPage {
  customer:any ;
  customerAddress:any
  constructor(public navCtrl: NavController, public navParams: NavParams) {
    console.log({funcion:"constructor",data:this,navParams})
    this.customer = this.navParams.data['customer'];
    this.customerAddress = this.navParams.data['address']
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad DetailPostInfoPage');
  }

}
