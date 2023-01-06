import { Component } from '@angular/core';
import { CustomToasterService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toaster.service';
declare var $:any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EticaretClientAngular';
constructor(){
  
}
  
}

$.get("https://localhost:7243/api/Products");
