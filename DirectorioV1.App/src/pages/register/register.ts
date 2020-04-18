import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { CategoriasProvider } from '../../providers/categorias/categorias';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

/**
 * Generated class for the RegisterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {
  view : string = 'clientes'
  data: any = {nombre:"",tipo_documento:"NIT",numero_documento:"",categoria:""}
  listadoDeCategorias : any[] = [];
  formGeneral:FormGroup;
  constructor(
    public navCtrl: NavController, 
    public navParams: NavParams,
    private categoriasProvider: CategoriasProvider,
    private fb:FormBuilder) {
      this.formGeneral = this.fb.group({
        'nombre':['',[Validators.required]],
        'tipo_documento':['',[Validators.required]],
        'numero_documento':['',[Validators.required]],
        'categoria':['',[Validators.required]]
      })
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
    this.cargarCategorias();
  }

  cargarCategorias(){
    this.categoriasProvider.obtenerCategorias()
    .subscribe(res => {
      if(res['esExitoso']){
        this.listadoDeCategorias = res['listadoDeCategorias']
      }else{
        alert(res['mensaje'])
      }
    })
  }

  GuardarInformacion(){
    console.log(this.data)
  }

}
