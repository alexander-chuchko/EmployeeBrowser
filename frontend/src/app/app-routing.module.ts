import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsListComponent } from './components/projects/projects-list/projects-list.component';
import { ProjectCreateComponent } from './components/projects/project-create/project-create.component';
import { ProjectUpdateComponent } from './components/projects/project-update/project-update.component';
import { TaskListComponent } from './components/tasks/task-list/task-list.component';
import { TeamsCreateComponent } from './components/teams/teams-create/teams-create.component';
import { UsersListComponent } from './components/users/users-list/users-list.component';

const routes: Routes =[
  { path: 'projects', component: ProjectsListComponent},
  { path: 'projects/create', component: ProjectCreateComponent},
  { path: 'projects/update/:id', component: ProjectUpdateComponent},
  { path: 'users', component: TeamsCreateComponent},
  { path: 'teams', component: UsersListComponent},
  { path: 'tasks', component: TaskListComponent},
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
