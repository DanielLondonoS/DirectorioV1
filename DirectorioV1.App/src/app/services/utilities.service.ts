import { Injectable } from '@angular/core';
import { CallNumber } from '@ionic-native/call-number/ngx';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {
  callNumber:CallNumber = new CallNumber();
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
}
