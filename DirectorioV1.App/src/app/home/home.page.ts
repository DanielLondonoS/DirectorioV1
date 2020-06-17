import { Component, ChangeDetectorRef } from '@angular/core';
import { CustomersService } from '../services/customers.service';
import { Router } from '@angular/router';
import { UtilitiesService } from '../services/utilities.service';
import { AlertController } from '@ionic/angular';
declare var google;
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(
    private clientesProvider : CustomersService,
    private router: Router,
    private utilitiesServices : UtilitiesService,
    private ref: ChangeDetectorRef,
    private alertCtrl:AlertController
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

   async getClientsList() {
    this.utilitiesServices.presentLoading();
    this.clientesProvider.obtenerClientes()
      .subscribe(async res => {
        this.utilitiesServices.loading.dismiss();
        console.log({ funcion: "GetClientsList", res: res })
        let rta: any = res;
        if (rta != []) {
          this.listCustomerPost = rta;
          let resp:any =rta;
          let list:any[]=[];
          resp.forEach(element => {
            element['distance'] = null;
            element['duration'] = null;
            list.push(element)
          });
          console.log(list);
          this.listCustomerPost = list;
          await this.loadMap(rta)         
          this.ref.detectChanges()
        }

      },error => {
        console.log({ funcion: "GetClientsList", error: error })
        this.utilitiesServices.loading.dismiss();
      })
  }
/**
 * Inicializa los parametros en la busqueda
 */
  initializeItems() {
    this.search = true;
    this.listSearchPost = this.listCustomerPost;
  }
  /**
   * Obtiene la lista de la busqueda ingresada
   * @param ev 
   */
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
    if(customer['direcciones'].length > 1){
      this.presentAlertVariasDireccionesLlamada(customer);
    }else{
      this.utilitiesServices.makeCall(customer['direcciones'][0]['telefono']);
    }      
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

  geoClick(customer){
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

  async loadMap(listClients:any[]){
      this.utilitiesServices.getLocation().then(currentLocation => {
        const currentLatLng = new google.maps.LatLng(currentLocation.lat, currentLocation.lng);
        const mapElement: HTMLElement = document.getElementById('mapGuia')
        const directionsService = new google.maps.DirectionsService();
        const directionsRenderer = new google.maps.DirectionsRenderer();
        const map = new google.maps.Map(mapElement, {
          center: currentLatLng,
          zoom: 12,
          mapTypeId: google.maps.MapTypeId.ROADMAP,
          
        });
        google.maps.event.addListenerOnce(map, 'idle', () => {
          console.log('loaded map');
          console.log({ google: google, maps: google.maps });
          let newList:any[]=[]
          let k = 0;
          this.listCustomerPost.forEach(element => {
            let desLatLng = null;
            desLatLng = new google.maps.LatLng(element['direcciones'][0]['latitud'],element['direcciones'][0]['longitud']);
            directionsService.route({
              origin: currentLatLng,
              destination: desLatLng,
              travelMode: 'DRIVING'
            }, (response, status) => {
              console.log({ response: response, status: status })
              if (status === 'OK') {
                directionsRenderer.setDirections(response);
                element['distance'] = response['routes'][0]['legs'][0]['distance']['text'];
                element['duration'] = response['routes'][0]['legs'][0]['duration']['text'];
                // newList.push(element);
              } else {
                window.alert('Directions request failed due to ' + status);
              }
            });            
          });
          // this.listCustomerPost = [];
          // this.listCustomerPost = newList;
          // console.log({list:this.listCustomerPost})
        })
        directionsRenderer.setMap(map);
      })
  }
  async presentAlertVariasDireccionesLlamada(customer) {
    const alert = await this.alertCtrl.create({
      cssClass: 'my-custom-class',
      header: 'Información!',
      message: 'Este registro posee mas de un telefono o dirección, desea seleccionar alguna en especial?',
      buttons: [
        {
          text: 'NO',
          cssClass: 'secondary',
          handler: (blah) => {
            this.utilitiesServices.makeCall(customer['direcciones'][0]['telefono']);
          }
        }, {
          text: 'SI',
          handler: () => {
            this.viewDetail(customer);
          }
        }
      ]
    });

    await alert.present();
  }
}
