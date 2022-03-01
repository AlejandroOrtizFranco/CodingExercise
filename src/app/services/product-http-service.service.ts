import { Product } from './../models/product';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductHttpServiceService {

  constructor(private http: HttpClient) { }

  url = 'http://localhost:22946/api/products';

  getProducts(){
    return this.http.get<any>(`${this.url}`);
  }

  createProduct(product:Product){
    return this.http.post<any>(`${this.url}`, product);
  }

  updateProduct(product:Product){
    return this.http.put<any>(`${this.url}`,product);
  }

  deleteProduct(id: number){
    return this.http.delete<any>(`${this.url}/${id}`);
  }
}
