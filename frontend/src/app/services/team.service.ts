import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Team } from '../models/team/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  private baseUrl: string = environment.apiUrl;
  private url = "/api/teams";

  constructor(private http: HttpClient) {}

  getTeams() : Observable<Team[]> {
    let concatUrl = `${this.baseUrl}${this.url}`
      return this.http.get<Team[]>(concatUrl).pipe(
        catchError(this.handleError)
      );
  }
   
  getTeam(id: number): Observable<Team> {
    return this.http.get<Team>(`${this.baseUrl}${this.url}/${id}`).pipe(
        catchError(this.handleError)
      );
  }

  createTeam(team: Team): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}`, team).pipe(
      catchError(this.handleError)
    );
  }

  updateTeam(team: Team): Observable<Team> {
    return this.http.put<Team>(`${this.baseUrl}${this.url}/${team.id}`, team).pipe(
      catchError(this.handleError)
    );
  }

  deleteTeam(id: number): Observable<void> {
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
