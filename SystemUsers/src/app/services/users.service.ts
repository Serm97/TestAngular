import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

const API_URL = 'https://localhost:5001/api/users/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*'})
}

@Injectable({
  providedIn: 'root'
})


export class UsersService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(API_URL);
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(`${API_URL}${id}`)
  }

  addUser(entity: User): Observable<any> {
    return this.http.post(API_URL, entity, httpOptions);
  }

  updateUser(entity: User): Observable<any> {
    return this.http.put(API_URL, entity, httpOptions);
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${API_URL}${id}`, httpOptions);
  }
}
