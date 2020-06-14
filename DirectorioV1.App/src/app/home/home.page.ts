import { Component } from '@angular/core';
import { CustomersService } from '../services/customers.service';
import { Router } from '@angular/router';
import { CallNumber } from '@ionic-native/call-number/ngx';
import { UtilitiesService } from '../services/utilities.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(
    private clientesProvider : CustomersService,
    private router: Router,
    private utilitiesServices : UtilitiesService
  ) {}
  listCustomerPost: any[] = [];
  listSearchPost: any[] = [];
  search: boolean = false;
  ionViewDidLoad() {
    console.log('ionViewDidLoad HomePage');
  }

  ionViewDidEnter() {
    this.getClientsList();
  }

  regiterPage() {
    this.router.navigate(['/register'])
  }

  getClientsList() {
    this.clientesProvider.obtenerClientes()
      .subscribe(res => {
        console.log({ funcion: "GetClientsList", res: res })
        let rta: any = res;
        if (rta != []) {
          this.listCustomerPost = rta;
        }

      })
  }

  initializeItems() {
    this.search = true;
    this.listSearchPost = this.listCustomerPost;
  }

  getItems(ev: any) {
    if (ev.target.value == '') {
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
  /**
   * Make a call to first item of directions list to customer
   * @param customer Customer to call
   */
  makeCall(customer) {
    console.log({funcion:'makeCall',emmit:customer})
      this.utilitiesServices.makeCall(customer['direcciones'][0]['telefono']);
  }

  viewDetail(customer) {
    console.log(customer)
    if(customer['direcciones'].length == 1){
      this.router.navigate(['detail-post-info'],{
        state:{customer:customer,address:customer['direcciones'][0]}
      })//;,{customer:customer,address:customer['direcciones'][0]});
    }else{
      this.router.navigate(['detail-post'],{
        state : {customer:customer}
      });//,customer);
    }
  }
}
