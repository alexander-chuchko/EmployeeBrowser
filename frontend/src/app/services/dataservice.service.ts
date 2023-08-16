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
 
  constructor(private http: HttpClient) {
  }

  
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
    // Return an observable with a user-facing error message
    return throwError('Something bad happened; please try again later.');
  }
}
