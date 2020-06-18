import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UtilitiesService } from 'src/app/services/utilities.service';
import { GoogleMaps, GoogleMap, GoogleMapsEvent, ILatLng, Marker, BaseArrayClass, GoogleMapOptions, Spherical, HtmlInfoWindow } from '@ionic-native/google-maps';
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

  markerDes: any = null;
  markerOri: any = null;
  distancia:any=null;
  duracion:any= null;
  currentLocation: any = null;

  customer: any;
  customerAddress: any
  deviceLongitud: number;
  deviceLatitud: number;
  address: string;
  directionsService = new google.maps.DirectionsService();
  directionsRenderer = new google.maps.DirectionsRenderer();
  constructor(
    private router: Router,
    private utilitiesServices: UtilitiesService,
    private platform: Platform,
    private geolocation: Geolocation,
    private nativeGeocoder: NativeGeocoder,
  ) {
    console.log({ 'constructorDetailPostInfo': router, currentNavigation: router.getCurrentNavigation() })
    if (router.getCurrentNavigation().extras.state == undefined || router.getCurrentNavigation().extras.state == undefined)
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

  makeCall() {
    this.utilitiesServices.makeCall(this.customerAddress['telefono'])
  }
  /**
   * Carga el mapa de google
   */
  async loadMap() {
    this.utilitiesServices.presentLoading();
    this.currentLocation = await this.utilitiesServices.getLocation()
    const mapElement: HTMLElement = document.getElementById('map_canvas')
    const indicatorsElement:HTMLElement = document.getElementById('indicators')
    this.directionsService = new google.maps.DirectionsService();
    this.map = new google.maps.Map(mapElement, {
      center: this.currentLocation,
      zoom: 12,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
      
    });
    google.maps.event.addListenerOnce(this.map, 'idle', () => {
      console.log('loaded map');
      console.log({ google: google, maps: google.maps });
      let lat: number = this.customerAddress['latitud'] || 0;
      let lng: number = this.customerAddress['longitud'] || 0
      this.setMarker(lng, lat)
      this.utilitiesServices.loading.dismiss();
    })
    this.directionsRenderer.setMap(this.map);
    this.directionsRenderer.setPanel(indicatorsElement);
  }


  async loadMapNative() {
    const resp :ILatLng = await this.utilitiesServices.getLocation()
    const latlngCustomer :ILatLng = {lat:parseFloat(this.customerAddress['latitud']) ,lng: parseFloat(this.customerAddress['longitud'])}
    let mapOptions: GoogleMapOptions = {
      camera: {
        target: resp,
        zoom: 12,
        tilt: 30
      }
    }; 
    this.mapNativo = GoogleMaps.create("map_canvas", mapOptions);
    let customerName = this.customer['nombre'] || "Titulo";
    let markerDes: Marker = this.mapNativo.addMarkerSync({
      // title: customerName,
      icon: 'blue',
      animation: 'DROP',
      position: latlngCustomer
    });
    let markerOri: Marker = this.mapNativo.addMarkerSync({
      title: 'Tú',
      icon: 'red',
      animation: 'DROP',
      position: resp
    });
    console.log({markerOri:markerOri});
    this.mapNativo.addPolyline({points:[resp,latlngCustomer]})
    
    markerDes.on(GoogleMapsEvent.MARKER_CLICK).subscribe(() => {
      let htmlInfoWindow = new HtmlInfoWindow();

      let frame: HTMLElement = document.createElement('div');
      frame.style.textAlign = "center"
      frame.innerHTML = [
        '<h3 style="white-space:nowrap">'+customerName+'</h3>',
        '<img style="height:140px;width:auto;" src="'+this.customer['imagenes'][0]['imageFullPath']+'">'
      ].join("");
      frame.getElementsByTagName("img")[0].addEventListener("click", () => {
        // htmlInfoWindow.setBackgroundColor('red');
      });
      htmlInfoWindow.setContent(frame, {
        width: "250px",
        height: "200px"
      });

      htmlInfoWindow.open(markerDes);
    });
  }
  /**
   * Crea un marker en el mapa y el marker del dispositivo
   * @param lng 
   * @param lat 
   */
  private setMarker(lng: number, lat: number) {
    var customerLatlng = new google.maps.LatLng(lat, lng);
    let currentLatLng = new google.maps.LatLng(this.currentLocation['lat'], this.currentLocation['lng'])

    let customerName = this.customer['nombre'] || "Titulo";
    this.markerDes = new google.maps.Marker({
      position: customerLatlng,
      map: this.map,
      title: customerName
    });
    this.addInfoWindow(this.markerDes, customerName);
    this.markerOri = new google.maps.Marker(
      {
        position: currentLatLng,
        map: this.map,
        title: 'Tú'
      });
    this.addInfoWindow(this.markerOri, 'Tú');
    let desLatLng = new google.maps.LatLng(this.customerAddress['latitud'], this.customerAddress['longitud']);
    this.utilitiesServices.getLocation()
      .then(res => {
        let currentLatLng = new google.maps.LatLng(res.lat, res.lng);
        this.directionsService.route({
          origin: currentLatLng,
          destination: desLatLng,
          travelMode: 'DRIVING'
        }, (response, status) => {
          console.log({ response: response, status: status })
          if (status === 'OK') {
            this.directionsRenderer.setDirections(response);
            this.distancia = response['routes'][0]['legs'][0]['distance']['text'];
            this.duracion = response['routes'][0]['legs'][0]['duration']['text'];
          } else {
            window.alert('Directions request failed due to ' + status);
          }
        });
      }, error => {
        window.alert('Directions request failed due to ' + error);
      })
  }
  /**
   * Ingresa informacion al marcador
   * @param marker 
   * @param content 
   */
  addInfoWindow(marker, content) {
    let infoWindow = new google.maps.InfoWindow({
      content: content
    });
    google.maps.event.addListener(marker, 'click', () => {
      infoWindow.open(this.map, marker);
    });
  }
  
}
