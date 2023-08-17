import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Task } from '../models/task/task';
import { User } from '../models/user/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl: string = environment.apiUrl;
  private url = "/api/users";

  constructor(private http: HttpClient) {}

  getTasks() : Observable<User[]> {
    let concatUrl = `${this.baseUrl}${this.url}`
      return this.http.get<User[]>(concatUrl).pipe(
        catchError(this.handleError)
      );
  }

   
  getTask(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}${this.url}/${id}`).pipe(
        catchError(this.handleError)
      );
  }

  createTask(task: User): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}`, task).pipe(
      catchError(this.handleError)
    );
  }

  updateTask(task: User): Observable<User> {
    return this.http.put<User>(`${this.baseUrl}${this.url}/${task.id}`, task).pipe(
      catchError(this.handleError)
    );
  }

  deleteTask(id: number): Observable<void> {
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
