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
   
  getProject(id: number) {
      return this.http.get(this.baseUrl + this.url + '/' + id);
  }
   
  createProject(project: Project) {
      return this.http.post(this.baseUrl + this.url, project);
  }

  updateProject(project: Project) {

      return this.http.put(this.baseUrl + this.url, project);
  }

  deleteProject(id: number) {
      return this.http.delete(this.baseUrl + this.url + '/' + id);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      console.error('An error occurred:', error.error.message);
    } else {
      // Backend returned an unsuccessful response code
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message
    return throwError('Something bad happened; please try again later.');
  }
}
