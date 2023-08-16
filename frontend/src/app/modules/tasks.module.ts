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


@NgModule({
  declarations: [
    TaskListComponent,
    TaskCreateComponent,
    TaskUpdateComponent,
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
  ]
})
export class TasksModule { }
