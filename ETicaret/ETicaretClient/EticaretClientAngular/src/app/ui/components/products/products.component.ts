import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends BaseComponent implements OnInit{
  constructor(spinner:NgxSpinnerService){
    super(spinner);
  }
 
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
