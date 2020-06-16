import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UtilitiesService } from 'src/app/services/utilities.service';
import {  GoogleMaps, GoogleMap, GoogleMapsEvent, ILatLng, Marker, BaseArrayClass, GoogleMapOptions } from '@ionic-native/google-maps';
import { Platform } from '@ionic/angular';
import { NativeGeocoder, NativeGeocoderOptions, NativeGeocoderResult } from '@ionic-native/native-geocoder/ngx';
import { Geolocation } from '@ionic-native/geolocation/ngx';

declare var google;

@Component({
  selector: 'app-detail-post-info',
  templateUrl: './detail-post-info.page.html',
  styleUrls: ['./detail-post-info.page.scss'],
})
export class DetailPostInfoPage implements OnInit {
  @ViewChild('map_canvas', { static: false }) map_canvas: ElementRef;
  mapNativo: GoogleMap;
  map:any = null;
  customer: any;
  customerAddress: any
  deviceLongitud: number;
  deviceLatitud: number;
  address: string;
  directionsService = new google.maps.DirectionsService();
  directionsRenderer = new google.maps.DirectionsRenderer();
  constructor(
    private router:Router,
    private utilitiesServices:UtilitiesService,
    private platform : Platform,
    private geolocation: Geolocation,
    private nativeGeocoder: NativeGeocoder,
  ) {
    console.log({'constructorDetailPostInfo':router,currentNavigation:router.getCurrentNavigation()})
    if(router.getCurrentNavigation().extras.state == undefined || router.getCurrentNavigation().extras.state == undefined)
      this.router.navigate(['/home'])
    this.customer = router.getCurrentNavigation().extras.state['customer'];
    this.customerAddress = router.getCurrentNavigation().extras.state['address'];
  }

  async ngOnInit() {
    await this.platform.ready();
    if(this.platform.is("ios") || this.platform.is("android")){
      this.loadMapNative();
    }else{
      await this.loadMap();
    }
  }

  makeCall(data:any){
    this.utilitiesServices.makeCall(this.customerAddress['telefono'])
  }

  async loadMap() {
    const resp = await this.getLocation()
    const mapElement : HTMLElement = document.getElementById('map_canvas')  
      
    this.map = new google.maps.Map(mapElement,{
      center : resp,
      zoom: 18,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    google.maps.event.addListenerOnce(this.map, 'idle', () => {
      console.log('loaded map');
      console.log({google:google,maps:google.maps});
      let lat:number = this.customerAddress['ciudad']['latitud'] || 0;
      let lng:number = this.customerAddress['ciudad']['longitud'] || 0
      this.setMarker(resp.lng,resp.lat)
    }) 
    this.directionsRenderer.setMap(this.map);
     
  }

  async loadMapNative() {
    const resp :ILatLng = await this.getLocation()
    const latlngCustomer :ILatLng = {lat:this.customerAddress['ciudad']['latitud'] ,lng: this.customerAddress['ciudad']['longitud']}
    let mapOptions: GoogleMapOptions = {
      camera: {
        target: resp,
        zoom: 18,
        tilt: 30
      }
    }; 
    this.mapNativo = GoogleMaps.create("map_canvas", mapOptions);

    let markerOri: Marker = this.mapNativo.addMarkerSync({
      title: 'Ionic',
      icon: 'blue',
      animation: 'DROP',
      position: latlngCustomer
    });   
     
  }

  private setMarker(lng:number,lat:number){
    var myLatlng = new google.maps.LatLng(lat,lng);
    let customerName = this.customer['nombre'] || "Titulo";
    const marker = new google.maps.Marker({
      position:myLatlng,
      map:this.map,
      title: customerName
    })
    this.addInfoWindow(marker,customerName)
    google.maps.event.addListener(marker,'click',res => {
      console.log({eventMarker:res})
      this.map.setZoom(15);
      this.map.setCenter(marker.getPosition());


    });
    marker.addListener('click',res => {
      console.log(event)
      let desLatLng = new google.maps.LatLng(this.customerAddress['latitud'],this.customerAddress['longitud']);
      this.directionsService.route({
          origin: myLatlng,
          destination: desLatLng,
          travelMode: 'DRIVING'
      }, function(response, status) {
          if (status === 'OK') {
            new google.maps.DirectionsRenderer().setDirections(response);
          } else {
              window.alert('Directions request failed due to ' + status);
          }
      });

  });
  }

  addInfoWindow(marker, content) {

    let infoWindow = new google.maps.InfoWindow({
        content: content
    });

    google.maps.event.addListener(marker, 'click', () => {
        infoWindow.open(this.map, marker);
    });

}

  private async getLocation(){
    let resp = await this.geolocation.getCurrentPosition();
    console.log({finction:'loadMapCoord',coor:resp})
    this.deviceLatitud = resp.coords.latitude
    this.deviceLongitud = resp.coords.longitude
    return {
      lat: this.deviceLatitud,
      lng: this.deviceLongitud
    }
  }
 

 


}
