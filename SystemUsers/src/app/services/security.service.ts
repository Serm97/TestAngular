import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http'
import { AppUserAuth } from '../models/app-user-auth';
import { AppUser } from '../models/app-user';
import { tap, catchError } from 'rxjs/operators'
import { throwError } from 'rxjs';

const _urlApi = 'https://localhost:5001/api/account/';
const _httpOptions = {
  headers: new HttpHeaders({'Content-type':'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  securityObject : AppUserAuth = new AppUserAuth();

  constructor(private http: HttpClient) { }

  login(entity: AppUser){
    return this.http.post(`${_urlApi}login`, entity, _httpOptions)
    .pipe(
      tap((res: AppUserAuth) => {
        Object.assign(this.securityObject, res);
        localStorage.setItem('token', this.securityObject.token);
      }),
      catchError(this.handleError)
    )
  }

  logout(){
    this.resetSecurityObject
  }

  handleError(err: any){
    return throwError(err.error);
    
  }

  resetSecurityObject(){
    this.securityObject.token = '';
    this.securityObject.expiration = '';
    this.securityObject.isAuthenticated = false;
    localStorage.removeItem('token');
  }
}
