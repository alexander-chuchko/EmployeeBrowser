import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsListComponent } from './components/projects/projects-list/projects-list.component';
import { ProjectCreateComponent } from './components/projects/project-create/project-create.component';
import { ProjectUpdateComponent } from './components/projects/project-update/project-update.component';
import { TaskListComponent } from './components/tasks/task-list/task-list.component';
import { TeamsCreateComponent } from './components/teams/teams-create/teams-create.component';
import { UsersListComponent } from './components/users/users-list/users-list.component';
import { TaskCreateComponent } from './components/tasks/task-create/task-create.component';
import { TaskUpdateComponent } from './components/tasks/task-update/task-update.component';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';
import { TeamsUpdateComponent } from './components/teams/teams-update/teams-update.component';
import { UsersCreateComponent } from './components/users/users-create/users-create.component';
import { UsersUpdateComponent } from './components/users/users-update/users-update.component';
import { CanDeactivateGuard } from './guards/can-deactivate.guard';

const routes: Routes =[
  { path: 'projects', component: ProjectsListComponent},
  { path: 'projects/create', component: ProjectCreateComponent},
  { path: 'projects/update/:id', component: ProjectUpdateComponent, canDeactivate: [CanDeactivateGuard]},
  { path: 'tasks', component: TaskListComponent},
  { path: 'tasks/create', component: TaskCreateComponent},
  { path: 'tasks/update/:id', component: TaskUpdateComponent},
  { path: 'teams', component: TeamsListComponent},
  { path: 'teams/create', component: TeamsCreateComponent},
  { path: 'teams/update/:id', component: TeamsUpdateComponent},
  { path: 'users', component: UsersListComponent},
  { path: 'users/create', component: UsersCreateComponent},
  { path: 'users/update/:id', component: UsersUpdateComponent},
  { path: '**', redirectTo: 'projects' }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
