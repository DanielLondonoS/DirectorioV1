import { Injectable } from '@angular/core';
import { CallNumber } from '@ionic-native/call-number/ngx';
import { LoadingController } from '@ionic/angular';
import { Geolocation } from '@ionic-native/geolocation/ngx';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {
  callNumber:CallNumber = new CallNumber();
  loadingController: LoadingController = new LoadingController();
  geolocation:Geolocation = new Geolocation();
  loading:any
  constructor() { }
  /**
   * Make a call to number
   * @param number Number to call
   */
  makeCall(number:any){
    this.callNumber.callNumber(number, true)
  .then(res => console.log('Launched dialer!', res))
  .catch(err => console.log('Error launching dialer', err));
  }

  async presentLoading(){
    this.loading = await this.loadingController.create({
      cssClass: 'my-custom-class',
      message: 'Please wait...',
    });
    await this.loading.present();
  }

  /**
   * Obtiene las coordenadas del dispositivo
   */
  async getLocation() {
    let resp = await this.geolocation.getCurrentPosition();
    console.log({ finction: 'getLocation', coor: resp })
    return {
      lat: resp.coords.latitude,
      lng: resp.coords.longitude
    }
  }

  presentAlert(){
    
  }


}
