import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/common/auth.service';
import { CustomToasterService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toaster.service';
declare var $:any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'EticaretClientAngular';
  constructor(public authService: AuthService, private toastrService: CustomToasterService, private router: Router) {
    authService.identityCheck();
  }
signOut() {
  localStorage.removeItem("accessToken");
  this.authService.identityCheck();
  this.router.navigate([""]);
  this.toastrService.message("Oturum kapatılmıştır!", "Oturum Kapatıldı", {
    messageType: ToastrMessageType.Warning,
    position: ToastrPosition.TopRight
  });  

}


}