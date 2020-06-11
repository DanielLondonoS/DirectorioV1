import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { DetailPostInfoPage } from './detail-post-info';

@NgModule({
  declarations: [
    DetailPostInfoPage,
  ],
  imports: [
    IonicPageModule.forChild(DetailPostInfoPage),
  ],
})
export class DetailPostInfoPageModule {}
