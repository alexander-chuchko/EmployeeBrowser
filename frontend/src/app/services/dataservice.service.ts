import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable, catchError, throwError } from 'rxjs';
import { Project } from '../models/project/project';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private baseUrl: string = environment.apiUrl;
  private url = "/api/projects";

  constructor(private http: HttpClient) {}
  /*
  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  create(entity: T): Observable<T> {
    return this.http.post<T>(this.baseUrl, entity).pipe(
      catchError(this.handleError)
    );
  }

  update(entity: T, id: number): Observable<T> {
    const url = `${this.baseUrl}${this.url}/${id}`;
    return this.http.put<T>(url, entity).pipe(
      catchError(this.handleError)
    );
  }*/


  getProjects() : Observable<Project[]> {
    let concatUrl = `${this.baseUrl}${this.url}`;
      return this.http.get<Project[]>(concatUrl)
      .pipe(
        catchError(this.handleError)
      );
  }
   
  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.baseUrl}${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }
   
  createProject(project: Project): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}`, project).pipe(
      catchError(this.handleError)
    );
  }

  updateProject(project: Project): Observable<Project> {
    return this.http.put<Project>(`${this.baseUrl}${this.url}/${project.id}`, project).pipe(
      catchError(this.handleError)
    );
  }

  deleteProject(id: number): Observable<void> {
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
