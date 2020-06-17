import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy, LoadingController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule }    from '@angular/common/http';
import { CustomersService } from './services/customers.service';
import { CallNumber } from '@ionic-native/call-number/ngx';
import { UtilitiesService } from './services/utilities.service';
import { Geolocation } from '@ionic-native/geolocation/ngx';
import { NativeGeocoder } from '@ionic-native/native-geocoder/ngx';
import { GoogleMaps } from '@ionic-native/google-maps';
import { CategoriesService } from './services/categories.service';
@NgModule({
  declarations: [AppComponent],
  entryComponents: [
  ],
  imports: [
    BrowserModule, 
    IonicModule.forRoot(), 
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
    CustomersService,
    CallNumber,
    UtilitiesService,
    Geolocation,
    NativeGeocoder,
    GoogleMaps,
    CategoriesService

  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
