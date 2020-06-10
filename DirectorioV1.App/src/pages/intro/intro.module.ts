import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { IntroPage } from './intro';
import { PostComponent } from '../../components/post/post';

@NgModule({
  declarations: [
    IntroPage,
    PostComponent
  ],
  imports: [
    IonicPageModule.forChild(IntroPage),
  ]
})
export class IntroPageModule {}

// ,
//   schemas: [
//     CUSTOM_ELEMENTS_SCHEMA,
//     NO_ERRORS_SCHEMA
//   ]