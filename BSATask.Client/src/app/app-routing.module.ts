import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { ProjectsDetailsComponent } from './projects/projects-details/projects-details.component';
import { UsersDetailsComponent } from './users/users-details/users-details.component';
import { TeamsDetailsComponent } from './teams/teams-details/teams-details.component';
import { TasksDetailsComponent } from './tasks/tasks-details/tasks-details.component';

const appRoutes: Routes =[
  { path: 'projects', component: ProjectsDetailsComponent},
  { path: 'users', component: UsersDetailsComponent},
  { path: 'teams', component: TeamsDetailsComponent},
  { path: 'tasks', component: TasksDetailsComponent},
  { path: '**', redirectTo: 'projects' }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AppRoutingModule { }
