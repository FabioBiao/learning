import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Response } from './response';
import { UserClaim } from './user-claim';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  myUrl = 'http://localhost:4200/';
  constructor(private http: HttpClient) {}

  public signIn(email: string, password: string) {
    return this.http.post<Response>(this.myUrl + 'api/auth/login', {
      email: email,
      password: password,
    });
  }

  public signOut() {
    return this.http.get(this.myUrl + 'api/auth/logout');
  }

  public user() {
    return this.http.get<UserClaim[]>(this.myUrl + 'api/auth/user');
  }

  public isSignedIn(): Observable<boolean> {
    return this.user().pipe(
      map((userClaims) => {
        const hasClaims = userClaims.length > 0;
        return !hasClaims ? false : true;
      }),
      catchError((error) => {
        return of(false);
      })
    );
  }
}
