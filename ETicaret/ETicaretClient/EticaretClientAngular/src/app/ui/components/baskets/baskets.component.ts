import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-baskets',
  templateUrl: './baskets.component.html',
  styleUrls: ['./baskets.component.css']
})
export class BasketsComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService){
    super(spinner);
  }
 
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
