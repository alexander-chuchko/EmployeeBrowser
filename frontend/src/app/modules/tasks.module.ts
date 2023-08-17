import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskCreateComponent } from '../components/tasks/task-create/task-create.component';
import { TaskUpdateComponent } from '../components/tasks/task-update/task-update.component';
import { TaskListComponent } from '../components/tasks/task-list/task-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import { TaskDirective } from '../directives/taskdirective';


@NgModule({
  declarations: [
    TaskListComponent,
    TaskCreateComponent,
    TaskUpdateComponent,
    TaskDirective 
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatButtonModule,
    MatSelectModule,
  ]
})
export class TasksModule { }
