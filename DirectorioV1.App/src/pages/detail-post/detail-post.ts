import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { DetailPostInfoPage } from '../detail-post-info/detail-post-info';

/**
 * Generated class for the DetailPostPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-detail-post',
  templateUrl: 'detail-post.html',
})
export class DetailPostPage {
  customer:any={}
  
  constructor(public navCtrl: NavController, public navParams: NavParams) {
    console.log(this.navParams)
    this.customer = this.navParams.data;
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad DetailPostPage', this.customer);
  }

  detailPostInfo(item,index){
    console.log({detailPostInfo:'DetailPostInfo',item:item,index:index})
    this.navCtrl.push(DetailPostInfoPage,{customer:this.customer,address:item})
  }

}
