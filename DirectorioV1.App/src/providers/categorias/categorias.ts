import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API } from '../../constantes/config';


/*
  Generated class for the CategoriasProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class CategoriasProvider {
  url : string = API.url;
  headers = new HttpHeaders({"Access-Control-Allow-Origin":"*"})
  constructor(public http: HttpClient) {
    console.log('Hello CategoriasProvider Provider');
  }

  obtenerCategorias(){
    return this.http.get(`${this.url}Categories/getCategories`,{
      headers:this.headers
    });
  }

}
