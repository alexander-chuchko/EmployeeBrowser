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
import { ProjectUpdateComponent } from './components/projects/project-update/project-update.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationMenuComponent,
  ],
  imports: [
    BrowserModule,
    UsersModule,
    TeamsModule,
    TasksModule,
    ProjectsModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
