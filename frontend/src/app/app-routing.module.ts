import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsDetailsComponent } from './components/projects-details/projects-details.component';
import { UsersDetailsComponent } from './components/users-details/users-details.component';
import { TeamsDetailsComponent } from './components/teams-details/teams-details.component';
import { TasksDetailsComponent } from './components/tasks-details/tasks-details.component';

const routes: Routes =[
  { path: 'projects', component: ProjectsDetailsComponent},
  { path: 'users', component: UsersDetailsComponent},
  { path: 'teams', component: TeamsDetailsComponent},
  { path: 'tasks', component: TasksDetailsComponent},
  { path: '**', redirectTo: 'projects' }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
