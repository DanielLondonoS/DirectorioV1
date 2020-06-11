import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { IntroPageModule } from '../pages/intro/intro.module';
import { RegisterPageModule } from '../pages/register/register.module';
import { CategoriasProvider } from '../providers/categorias/categorias';
import { HttpClientModule } from '@angular/common/http';
import { ClientesProvider } from '../providers/clientes/clientes';
import { DetailPostPageModule } from '../pages/detail-post/detail-post.module';
import { DetailPostInfoPageModule } from '../pages/detail-post-info/detail-post-info.module';

@NgModule({
  declarations: [
    MyApp,
    HomePage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    IntroPageModule,
    RegisterPageModule,
    HttpClientModule,
    DetailPostPageModule,
    DetailPostInfoPageModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    CategoriasProvider,
    ClientesProvider
  ]
})
export class AppModule {}
