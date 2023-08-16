import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Task } from '../models/task/task';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  private baseUrl: string = environment.apiUrl;
  private url = "/api/tasks";

  constructor(private http: HttpClient) {}

  getTasks() : Observable<Task[]> {
    let concatUrl = `${this.baseUrl}${this.url}`;
      return this.http.get<Task[]>(concatUrl)
      .pipe(
        catchError(this.handleError)
      );
  }
   
  getTask(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }
   
  createTask(project: Task): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}`, project).pipe(
      catchError(this.handleError)
    );
  }

  updateTask(project: Task): Observable<Task> {
    return this.http.put<Task>(`${this.baseUrl}${this.url}/${project.id}`, project).pipe(
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
