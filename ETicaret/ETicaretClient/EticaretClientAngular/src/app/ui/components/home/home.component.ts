import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService){
    super(spinner);
  }
 
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
