import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { CustomersService } from '../services/customers.service';
import { Router } from '@angular/router';
import { UtilitiesService } from '../services/utilities.service';
import { AlertController } from '@ionic/angular';
import { CategoriesService } from '../services/categories.service';
declare var google;
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {
  segmentModel = "explorar";
  listCustomerPost: any[] = [];
  listSearchPost: any[] = [];
  listCercaMi:any[]=[];
  listCategories:any=[]=[];
  search: boolean = false;
  constructor(
    private clientesProvider: CustomersService,
    private router: Router,
    private utilitiesServices: UtilitiesService,
    private categoriesProvider: CategoriesService,
    private ref: ChangeDetectorRef,
    private alertCtrl: AlertController
  ) { }
  
  ngOnInit() {
    console.log('ionViewDidLoad HomePage');
    this.presentAlertCategorias();
  }

  segmentChanged(event){
    console.log(this.segmentModel);
    switch (this.segmentModel) {
      case 'explorar':
        
        break;
        case 'cercami':
          this.listCercaMi = this.listCustomerPost.sort(function (a: any, b: any) {
            return a['distance'].split(' ')[0] - b['distance'].split(' ')[0]
          })
          break;
          case 'categorias':
        
          break;
      default:
        break;
    }
    
    console.log(event);
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
          let resp: any = rta;
          let list: any[] = [];
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

      }, error => {
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
      let list:any = this.listSearchPost.filter((item) => {
        return ((item['nombre'].toLowerCase().indexOf(val.toLowerCase()) > -1) || (item['categoria']['descripcion'].toLowerCase().indexOf(val.toLowerCase()) > -1));
      })
      this.listSearchPost = list.sort(function(a:any,b:any){
        return a['distance'].split(' ')[0] - b['distance'].split(' ')[0]
      })
    }
  }
  /**
   * Make a call to first item of directions list to customer
   * @param customer Customer to call
   */
  makeCall(customer) {
    console.log({ funcion: 'makeCall', emmit: customer })
    if (customer['direcciones'].length > 1) {
      this.presentAlertVariasDireccionesLlamada(customer);
    } else {
      this.utilitiesServices.makeCall(customer['direcciones'][0]['telefono']);
    }
  }

  viewDetail(customer) {
    console.log(customer)
    if (customer['direcciones'].length == 1) {
      this.router.navigate(['detail-post-info'], {
        state: { customer: customer, address: customer['direcciones'][0] }
      })//;,{customer:customer,address:customer['direcciones'][0]});
    } else {
      this.router.navigate(['detail-post'], {
        state: { customer: customer }
      });//,customer);
    }
  }

  geoClick(customer) {
    if (customer['direcciones'].length == 1) {
      this.router.navigate(['detail-post-info'], {
        state: { customer: customer, address: customer['direcciones'][0] }
      })//;,{customer:customer,address:customer['direcciones'][0]});
    } else {
      this.router.navigate(['detail-post'], {
        state: { customer: customer }
      });//,customer);
    }
  }

  async loadMap(listClients: any[]) {
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
        let newList: any[] = []
        let k = 0;
        this.listCustomerPost.forEach(element => {
          let desLatLng = null;
          desLatLng = new google.maps.LatLng(element['direcciones'][0]['latitud'], element['direcciones'][0]['longitud']);
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

  async presentAlertCategorias() {
    // this.utilitiesServices.presentLoading();
    this.categoriesProvider.obtenerCategorias()
      .subscribe(async res => {
        let listCategorias: any = res;
        this.listCategories = res;
        let inputs: any = [];
        listCategorias.forEach(element => {
          let item = {
            name: 'radio1',
            type: 'radio',
            label: element['descripcion'],
            value: element['descripcion'],
            checked: false
          };
          inputs.push(item);
        });
        // this.utilitiesServices.loading.dismiss();

        const alert = await this.alertCtrl.create({
          cssClass: 'my-custom-class',
          header: '¿Que estas buscando?',
          inputs: inputs,
          buttons: [
            {
              text: 'Cancel',
              role: 'cancel',
              cssClass: 'secondary',
              handler: () => {
                console.log('Confirm Cancel');
              }
            }, {
              text: 'Ok',
              handler: (value) => {
                console.log({ funcion: 'Seleccion Categoria', value: value });
                this.filtroCategoria(value);
              }
            }
          ]
        });

        await alert.present();
      });
  }

  /**
   * Obtiene la lista de la busqueda ingresada
   * @param ev 
   */
  async filtroCategoria(categoria: any) {
    this.listSearchPost = this.listCustomerPost;
    // set val to the value of the searchbar
    const val = categoria;
    // if the value is an empty string don't filter the items
    if (val && val.trim() != '') {
      this.listSearchPost = this.listSearchPost.filter((item) => {
        return ((item['nombre'].toLowerCase().indexOf(val.toLowerCase()) > -1) || (item['categoria']['descripcion'].toLowerCase().indexOf(val.toLowerCase()) > -1));
      })
    }
    if (this.listSearchPost.length > 0) {
      this.listCustomerPost = this.listSearchPost.sort(function (a: any, b: any) {
        return a['distance'].split(' ')[0] - b['distance'].split(' ')[0]
      });
    } else {
      const alert = await this.alertCtrl.create({
        cssClass: 'my-custom-class',
        header: '¿Ups!!!?',
        subHeader: 'Lo sentimos',
        message: 'El resultado de la busqueda no arrojo ningun registro.',
        buttons: ['OK']
      });

      await alert.present();
    }
  }

  onCategoriesClick(item){
    this.filtroCategoria(item['descripcion']);
    this.segmentModel = 'explorar'
  }
}
