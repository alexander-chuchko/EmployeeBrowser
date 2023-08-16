import { Component, Input } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { TaskState } from 'src/app/models/enum/task-state';
import { Task } from 'src/app/models/task/task';
import { TasksService } from 'src/app/services/taskservice.service';

@Component({
  selector: 'app-task-create',
  templateUrl: './task-create.component.html',
  styleUrls: ['./task-create.component.css']
})
export class TaskCreateComponent {

  taskForm!: FormGroup;
  @Input() task: Task = {} as Task;

  states: any[] = [
    { value: 0, viewValue: 'To Do' },
    { value: 1, viewValue: 'In Progress' },
    { value: 2, viewValue: 'Done' },
    { value: 3, viewValue: 'Canceled' },
  ];


  constructor(private taskService: TasksService, private router: Router) { }

  onSubmit() {  
    if (this.taskForm.valid) {
      const newTask: Task = {
        id:0,
        name: this.taskForm.value.name,
        userId: this.taskForm.value.userId,
        projectId: this.taskForm.value.projectId,
        description: this.taskForm.value.description,
        state: parseInt(this.taskForm.value.state) as TaskState,
        createdAt:moment(this.taskForm.value.createdAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
        finishedAt:moment(this.taskForm.value.finishedAt, 'MM/DD/YYYY').format('YYYY-MM-DD'), 
      };


      this.taskService.createTask(newTask).subscribe(
        (response: Task) => {
          console.log('Task saved successfully:', response);
          this.router.navigate(['/tasks']);
        },
        (error: Task) => {
          console.error('Error saving project:', error);
        }
      );
    }
  }

  ngOnInit(): void {
    this.taskForm = new FormGroup({
      'name': new FormControl(this.task.name, [
        Validators.required,
        Validators.minLength(3)
      ]),
      'userId': new FormControl(this.task.userId, [
        Validators.required,
        this.validateId
      ]),
      'projectId': new FormControl(this.task.projectId, [
        Validators.required,
        this.validateId
      ]),
      'description': new FormControl(this.task.description, [
        Validators.required,
        Validators.minLength(20)
      ]),
      'state': new FormControl(this.task.description, [
        Validators.required,
      ]),
      'createdAt': new FormControl(this.task.createdAt, [
        Validators.required,
        this.dateVaidator
      ]),
      'finishedAt': new FormControl(this.task.finishedAt, [
        Validators.required,
        this.dateVaidator
      ]),
    });
  }

  validateId(control: AbstractControl): ValidationErrors | null {
    const value = control.value;
    if (isNaN(value)) {
      return { invalidUserId: true };
    }

    return null;
  }

  dateVaidator(control: AbstractControl) {
    if (control && control.value && !moment(control.value, 'MM/DD/YYYY', true).isValid()) {
      return { 'dateVaidator': true };
    }
    return null;
  }
}
