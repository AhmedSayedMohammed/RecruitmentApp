import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ILogin } from 'src/app/shared/classes/ilogin';
import { IResponse } from 'src/app/shared/wrapper/iresponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'https://localhost:7052/api/Users/'
  constructor(private http:HttpClient, private router:Router) { }
  user$ = new BehaviorSubject<null|ILogin>(null)
  isLoggedIn = new BehaviorSubject<boolean>(false);
  isLoggedInListener = this.isLoggedIn.asObservable()
  login(email:string, password:string){
    return this.http.post<IResponse<ILogin>>(this.baseUrl+email+'/'+ password, {});
  }

  saveUserToSessionStorage(data:ILogin){
    sessionStorage.setItem("currentuser",JSON.stringify(data))
  }
  getUserFromSessionStorage(){
    const user = <null | ILogin>JSON.parse(<string>sessionStorage.getItem("currentuser")) ;
    if(user){
      this.user$.next(user)
      return user
    }else{
      this.user$.next(null)
      return null
    }
  }
  clearSessionStorage(){
    sessionStorage.removeItem("currentuser")
  }
  logOut(){
    this.clearSessionStorage();
    this.isLoggedIn.next(false);
    this.user$.next(null);
    this.router.navigateByUrl('/authantication/login');
  }
}
