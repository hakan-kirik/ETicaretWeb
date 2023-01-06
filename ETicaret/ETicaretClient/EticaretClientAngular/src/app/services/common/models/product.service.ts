import { Injectable } from '@angular/core';
import { Create_product } from 'src/app/contracts/Create_product';
import { HttpClientService } from '../http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService:HttpClientService) { }

  create(product :Create_product,successCallBack?:any){
      this.httpClientService.post({
        controller:"products"
      },product).subscribe(result=>{
        successCallBack();
        alert("basarili");
      });
  }
}
