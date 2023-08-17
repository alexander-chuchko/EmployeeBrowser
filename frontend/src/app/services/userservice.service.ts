import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { User } from '../models/user/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl: string = environment.apiUrl;
  private url = "/api/users";

  constructor(private http: HttpClient) {}

  getUsers() : Observable<User[]> {
    let concatUrl = `${this.baseUrl}${this.url}`
      return this.http.get<User[]>(concatUrl).pipe(
        catchError(this.handleError)
      );
  }

   
  getUser(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}${this.url}/${id}`).pipe(
        catchError(this.handleError)
      );
  }

  createUser(user: User): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}`, user).pipe(
      catchError(this.handleError)
    );
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<User>(`${this.baseUrl}${this.url}/${user.id}`, user).pipe(
      catchError(this.handleError)
    );
  }

  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}${this.url}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError('Something bad happened; please try again later.');
  }
}
