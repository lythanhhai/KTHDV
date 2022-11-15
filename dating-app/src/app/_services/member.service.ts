import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/models/app-user';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = 'https://localhost:7254/api/members'
  constructor(private httpClient : HttpClient) {

   }
   getMembers() : Observable<Member[]>
   {
    return this.httpClient.get<Member[]>(this.baseUrl);
   }

   getMemberByUsername(username: string) : Observable<Member>
   {
    return this.httpClient.get<Member>(`${this.baseUrl} + "/" + ${username}`);
   }
}
