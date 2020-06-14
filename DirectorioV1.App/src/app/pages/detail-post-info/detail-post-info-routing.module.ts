import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DetailPostInfoPage } from './detail-post-info.page';

const routes: Routes = [
  {
    path: '',
    component: DetailPostInfoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DetailPostInfoPageRoutingModule {}
