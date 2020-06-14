import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DetailPostInfoPageRoutingModule } from './detail-post-info-routing.module';

import { DetailPostInfoPage } from './detail-post-info.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DetailPostInfoPageRoutingModule
  ],
  declarations: [DetailPostInfoPage]
})
export class DetailPostInfoPageModule {}
