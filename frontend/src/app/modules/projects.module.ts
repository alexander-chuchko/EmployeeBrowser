import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsListComponent } from '../components/projects/projects-list/projects-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectCreateComponent } from '../components/projects/project-create/project-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ProjectUpdateComponent } from '../components/projects/project-update/project-update.component';


@NgModule({
  declarations: [
    ProjectsListComponent, 
    ProjectCreateComponent,
    ProjectUpdateComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatButtonModule,
  ],
})

export class ProjectsModule { }
