import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsDetailsComponent } from '../components/projects-details/projects-details.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    ProjectsDetailsComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ]
})
export class ProjectsModule { }
