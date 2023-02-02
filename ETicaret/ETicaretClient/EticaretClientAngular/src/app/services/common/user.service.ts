import { Injectable } from '@angular/core';

import { firstValueFrom, Observable } from 'rxjs';
import { TokenResponse } from 'src/app/contracts/Token/TokenResponse';
import { Create_user } from 'src/app/contracts/Users/create_user';
import { User } from 'src/app/entities/user';
import { CustomToasterService, ToastrMessageType, ToastrPosition } from '../ui/custom-toaster.service';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService:HttpClientService,
        private toastrService:CustomToasterService
    ) { }


  async create(user:User):Promise<Create_user>{
        const observable:Observable<Create_user |User> =this.httpClientService.post<Create_user| User>({
          controller:"users"
        },user);   
        
        return await firstValueFrom(observable) as Create_user
  }

  async login(userNameOrEmail: string, password: string, callBackFunction?: () => void): Promise<any> {
    const observable: Observable<any|TokenResponse> = this.httpClientService.post<any |TokenResponse>({
      controller: "users",
      action: "login"
    }, { userNameOrEmail, password })

   const tokenResponse:TokenResponse = await firstValueFrom(observable) as TokenResponse;

   if(tokenResponse){
   
    
    localStorage.setItem("accessToken",tokenResponse.token.accessToken);
   
    
    this.toastrService.message("Kullanıcı girişi başarıyla sağlanmıştır.", "Giriş Başarılı", {
      messageType: ToastrMessageType.Success,
      position: ToastrPosition.TopRight
    })
   }
    callBackFunction();
  }
}
