import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { Create_user } from 'src/app/contracts/Users/create_user';
import { User } from 'src/app/entities/user';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService:HttpClientService) { }


  async create(user:User):Promise<Create_user>{
        const observable:Observable<Create_user |User> =this.httpClientService.post<Create_user| User>({
          controller:"users"
        },user);   
        
        return await firstValueFrom(observable) as Create_user
  }

  async login(userNameOrEmail: string, password: string, callBackFunction?: () => void): Promise<void> {
    const observable: Observable<any> = this.httpClientService.post({
      controller: "users",
      action: "login"
    }, { userNameOrEmail, password })

    await firstValueFrom(observable);
    callBackFunction();
  }
}
