import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { RegisterPage } from '../register/register';
import { ClientesProvider } from '../../providers/clientes/clientes';

/**
 * Generated class for the IntroPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-intro',
  templateUrl: 'intro.html',
})
export class IntroPage {
  listCustomerPost :any[] = [];
  listSearchPost:any[] = [];
  search:boolean=false;
  constructor(
    public navCtrl: NavController, 
    public navParams: NavParams,
    public clientesProvider: ClientesProvider
    ) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad IntroPage');
  }

  ionViewDidEnter(){
    this.getClientsList();
  }

  regiterPage(){
    this.navCtrl.push(RegisterPage)
  }

  getClientsList(){
    this.clientesProvider.obtenerClientes()
    .subscribe(res => {
      console.log({funcion:"GetClientsList",res:res})
      let rta :any = res;
      if(rta != []){
        this.listCustomerPost = rta;
      }
      
    })
  }

  initializeItems(){
    this.search = true;
    this.listSearchPost = this.listCustomerPost;
  }

  getItems(ev: any) {
    if(ev.target.value == ''){
      this.search = false;
      this.listSearchPost = [];
      return
    }
      
    // Reset items back to all of the items
    this.initializeItems();

    // set val to the value of the searchbar
    const val = ev.target.value;

    // if the value is an empty string don't filter the items
    if (val && val.trim() != '') {
      this.listSearchPost = this.listSearchPost.filter((item) => {
        return ((item['nombre'].toLowerCase().indexOf(val.toLowerCase()) > -1) || (item['categoria']['descripcion'].toLowerCase().indexOf(val.toLowerCase()) > -1));
      })
    }
  }
}
