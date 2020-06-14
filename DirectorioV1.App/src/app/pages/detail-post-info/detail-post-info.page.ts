import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UtilitiesService } from 'src/app/services/utilities.service';

@Component({
  selector: 'app-detail-post-info',
  templateUrl: './detail-post-info.page.html',
  styleUrls: ['./detail-post-info.page.scss'],
})
export class DetailPostInfoPage implements OnInit {
  // map: GoogleMap;
  customer: any;
  customerAddress: any
  deviceLongitud: any;
  deviceLatitud: any;
  constructor(
    private router:Router,
    private utilitiesServices:UtilitiesService
  ) {
    console.log({'constructorDetailPostInfo':router,currentNavigation:router.getCurrentNavigation()})
    this.customer = router.getCurrentNavigation().extras.state['customer'];
    this.customerAddress = router.getCurrentNavigation().extras.state['address'];
  }

  ngOnInit() {
  }

  makeCall(data:any){
    this.utilitiesServices.makeCall(this.customerAddress['telefono'])
  }

}
