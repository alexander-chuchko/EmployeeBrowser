import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsListComponent } from '../components/projects/projects-list/projects-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectCreateComponent } from '../components/projects/project-create/project-create.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ProjectsListComponent, 
    ProjectCreateComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
  ]
})
export class ProjectsModule { }
