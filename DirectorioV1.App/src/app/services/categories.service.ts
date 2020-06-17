import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { API } from '../consts/const';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  url : string = API.url;
  headers = new HttpHeaders({"Access-Control-Allow-Origin":"*"})
  constructor(private http:HttpClient) { }

  obtenerCategorias(){    
    this.headers.append("Access-Control-Request-Method","GET");
    this.headers.append("Access-Control-Request-Headers","Content-Type");
    this.headers.append("Content-Type","application/json");
    return this.http.get(`${this.url}Categories/getCategories`,{headers:this.headers});
    
  }
}
