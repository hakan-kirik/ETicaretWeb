import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';
import { SpinnerType } from 'src/app/base/base.component';
import { _isAuthenticated } from 'src/app/services/common/auth.service';
import { CustomToasterService, ToastrMessageType, ToastrPosition } from 'src/app/services/ui/custom-toaster.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router, private toastrService: CustomToasterService, private spinner: NgxSpinnerService) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      this.spinner.show(SpinnerType.BallSpin);
     

      if (!_isAuthenticated) {
        this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
        this.toastrService.message("Oturum açmanız gerekiyor!", "Yetkisiz Erişim!", {
          messageType: ToastrMessageType.Warning,
          position: ToastrPosition.TopRight
        })
        
      }
      this.spinner.hide(SpinnerType.BallSpin);
    return true;
  }

}
