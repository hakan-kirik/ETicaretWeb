import { SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { AuthService } from 'src/app/services/common/auth.service';
import { UserAuthService } from 'src/app/services/common/user-auth.service';
import { UserService } from 'src/app/services/common/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent {
  constructor(private userService: UserService, spinner: NgxSpinnerService,private authService: AuthService, private activatedRoute: ActivatedRoute, private router: Router
    ,private socialAuthService: SocialAuthService,private userAuthService:UserAuthService) {
    super(spinner)
    this.socialAuthService.authState.subscribe(async (user: SocialUser) => {
      console.log(user);
      this.showSpinner(SpinnerType.BallScaleMultiple);
      await this.userAuthService.googleLogin(user,()=>{
        this.authService.identityCheck();
        this.hideSpinner(SpinnerType.BallScaleMultiple);
      })
      
    });

  }

 

  async login(usernameOrEmail: string, password: string) {
    this.showSpinner(SpinnerType.BallScaleMultiple);
    await this.userAuthService.login(usernameOrEmail, password, () =>{ 
      this.authService.identityCheck();

      this.activatedRoute.queryParams.subscribe(params => {
        const returnUrl: string = params["returnUrl"];
        if (returnUrl)
          this.router.navigate([returnUrl]);
          else
          this.router.navigate([""]);
      });
      this.hideSpinner(SpinnerType.BallScaleMultiple);
    });
  }

}
