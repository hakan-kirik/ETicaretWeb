import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { UserService } from 'src/app/services/common/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent {
  constructor(private userService: UserService, spinner: NgxSpinnerService) {
    super(spinner)
  }

  ngOnInit(): void {
  }

  async login(usernameOrEmail: string, password: string) {
    this.showSpinner(SpinnerType.BallScaleMultiple);
    await this.userService.login(usernameOrEmail, password, () => this.hideSpinner(SpinnerType.BallScaleMultiple));
  }

}
