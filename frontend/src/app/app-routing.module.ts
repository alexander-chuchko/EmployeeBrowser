import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsListComponent } from './components/projects/projects-list/projects-list.component';
import { UsersDetailsComponent } from './components/users-details/users-details.component';
import { TeamsDetailsComponent } from './components/teams-details/teams-details.component';
import { TasksDetailsComponent } from './components/tasks-details/tasks-details.component';
import { ProjectCreateComponent } from './components/projects/project-create/project-create.component';

const routes: Routes =[
  { path: 'projects', component: ProjectsListComponent},
  { path: 'projects/create', component: ProjectCreateComponent},
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
