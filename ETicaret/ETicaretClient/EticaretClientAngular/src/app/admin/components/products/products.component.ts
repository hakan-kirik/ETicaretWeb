import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_product } from 'src/app/contracts/Create_product';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService,private httpClientService:HttpClientService){
    super(spinner);
  }
 
  @ViewChild(ListComponent) listComponents:ListComponent;

  createdProduct(create_product:Create_product){
      this.listComponents.getProducts();
  }
  ngOnInit(): void {
    //  this.showSpinner(SpinnerType.BallTrianglePath);
    // this.httpClientService.get({
    //   controller:"products"
    // }).subscribe(data=>console.log(data));

    //post process
    // this.httpClientService.post({
    //   controller:"products"
    // },{
    //   name:"kalem",
    //   stock:100,
    //   price:34
    // }).subscribe();

    //put process
    // this.httpClientService.put({controller:"products"},
    // {
    //   id:"b152e422-0fad-4843-94f7-51bfe977589c",
    //   name:"renkli kalem",
    //   stock:1233,
    //   price:33
    // }).subscribe();
    

    //delete Process
    // this.httpClientService.delete({controller:"products"},"b152e422-0fad-4843-94f7-51bfe977589c").subscribe();

    
  }

}
