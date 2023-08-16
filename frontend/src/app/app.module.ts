import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { ProjectsModule } from './modules/projects.module';
import { UsersModule } from './modules/users.module';
import { TeamsModule } from './modules/teams.module';
import { TasksModule } from './modules/tasks.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TaskListComponent } from './components/tasks/task-list/task-list.component';
import { TaskCreateComponent } from './components/tasks/task-create/task-create.component';
import { TaskUpdateComponent } from './components/tasks/task-update/task-update.component';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';
import { TeamsCreateComponent } from './components/teams/teams-create/teams-create.component';
import { TeamsUpdateComponent } from './components/teams/teams-update/teams-update.component';
import { UsersListComponent } from './components/users/users-list/users-list.component';
import { UsersCreateComponent } from './components/users/users-create/users-create.component';
import { UsersUpdateComponent } from './components/users/users-update/users-update.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationMenuComponent,
  ],
  imports: [
    BrowserModule,
    ProjectsModule,
    TasksModule,
    TeamsModule,
    UsersModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
