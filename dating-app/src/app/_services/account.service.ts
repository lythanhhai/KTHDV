import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, pipe, ReplaySubject } from 'rxjs';
import { AuthUser, RegisterUser, User, UserToken } from 'src/models/app-user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl: string = 'https://localhost:7254/api/Auth/';
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });
  private currentUser = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUser.asObservable();

  constructor(private httpClient: HttpClient) {}

  login(authUser: AuthUser): Observable<any> {
    return this.httpClient
      .post(`${this.baseUrl}login`, authUser, {
        responseType: 'text',
        headers: this.headers,
      })
      .pipe(
        map((token) => {
          if (token) {
            const userToken: UserToken = { username: authUser.username, token };
            this.currentUser.next(userToken);
            localStorage.setItem('userToken', JSON.stringify(userToken));
          }
        })
      );
  }

  logout() {
    this.currentUser.next(null);
    localStorage.removeItem('userToken');
  }

  reLogin() {
    const storageUser = localStorage.getItem('userToken');
    if (storageUser) {
      const currentUser = JSON.parse(storageUser);
      this.currentUser.next(currentUser);
    }
  }

  register(registerUser: RegisterUser): Observable<any> {
    return this.httpClient
      .post(`${this.baseUrl}register`, registerUser, {
        responseType: 'text',
        headers: this.headers,
      })
      .pipe(
        map((token) => {
          if (token) {
            const userToken: UserToken = {
              username: registerUser.username,
              token,
            };
            this.currentUser.next(userToken);
            localStorage.setItem('userToken', JSON.stringify(userToken));
          }
        })
      );
  }
}
