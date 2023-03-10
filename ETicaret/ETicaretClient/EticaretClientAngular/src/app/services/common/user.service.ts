import { SocialUser } from '@abacritt/angularx-social-login';
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

 
}
