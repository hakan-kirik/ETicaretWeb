import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Create_user } from 'src/app/contracts/Users/create_user';
import { User } from 'src/app/entities/user';
import { UserService } from 'src/app/services/common/user.service';
import { CustomToasterService, ToastrMessageType, ToastrPosition } from 'src/app/services/ui/custom-toaster.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private userService:UserService,
    private toastrService:CustomToasterService
    ) { }

 public frm: FormGroup;

  ngOnInit(): void {
    this.frm = this.formBuilder.group({
      nameSurname: ["", [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(3)
      ]],
      username: ["", [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(3)
      ]],
      email: ["", [
        Validators.required,
        Validators.maxLength(250),
        Validators.email
      ]],
      password: ["",
        [
          Validators.required
        ]],
      passwordConfirm: ["",
        [
          Validators.required
        ]]
    })
  }

  get component() {
    return this.frm.controls;
  }

  submitted: boolean = false;
  async onSubmit(user: User) {
    this.submitted = true;

    debugger;
    if (this.frm.invalid)
      return;

      
    const result:Create_user=await  this.userService.create(user);
    if(result.succeeded)
    this.toastrService.message(result.message, "Kullanıcı Kaydı Başarılı", {
      messageType: ToastrMessageType.Success,
      position: ToastrPosition.TopRight
    })
    else
      this.toastrService.message(
        result.message, "hata",{
          messageType:ToastrMessageType.Error,
          position:ToastrPosition.TopRight
        }
      )
  }
}
