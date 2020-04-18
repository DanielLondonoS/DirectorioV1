import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API } from '../../constantes/config';

/*
  Generated class for the ClientesProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class ClientesProvider {
  url : string = API.url;

  constructor(public http: HttpClient) {
    console.log('Hello ClientesProvider Provider');
  }

  obtenerClientes(){
    return this.http.get(`${this.url}Clientes/ObtenerClientes`);
  }

}
