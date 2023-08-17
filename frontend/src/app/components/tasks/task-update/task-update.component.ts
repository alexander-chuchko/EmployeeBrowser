import { Component, Input } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Observable, of } from 'rxjs';
import { TaskState } from 'src/app/models/enum/task-state';
import { Task } from 'src/app/models/task/task';
import { TasksService } from 'src/app/services/taskservice.service';

@Component({
  selector: 'app-task-update',
  templateUrl: './task-update.component.html',
  styleUrls: ['./task-update.component.css']
})
export class TaskUpdateComponent {

  taskForm!: FormGroup;
  @Input() task: Task = {} as Task;
  isSaved = false;

  constructor(private taskService: TasksService, private router: Router, private route: ActivatedRoute) { }

  canDeactivate(): Observable<boolean> {
    if (this.taskForm.dirty && !this.isSaved) {
      const result = window.confirm('There are unsaved changes! Are you sure?');
      return of(result);
    }
    return of(true);
  }
  
  onSubmit() {  
    this.isSaved = true;
    if (this.taskForm.valid) {
      let newTask: Task = {
        id:0,
        name: this.taskForm.value.name,
        userId: this.taskForm.value.userId,
        projectId: this.taskForm.value.projectId,
        description: this.taskForm.value.description,
        state: parseInt(this.taskForm.value.state) as TaskState,
        createdAt:this.taskForm.value.createdAt,
        finishedAt:this.taskForm.value.finishedAt, 
      };

      const getId = this.route.snapshot.paramMap.get('id');
      if(getId) {
        newTask.id = parseInt(getId);
      }

      this.taskService.updateTask(newTask).subscribe(
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
    this.setUpValidation();
    this.route.params.subscribe(params => {
      const taskId = +params['id'];
      this.taskService.getTask(taskId).subscribe(task => {
        this.initializingFieldsWithValues(task);
      });
    });
  }

  initializingFieldsWithValues(t: Task) {
    if (t) {
      this.taskForm.patchValue({
        'name': t?.name,
        'projectId': t?.projectId,
        'userId': t?.userId,
        'description': t?.description,
        'state':t.state.toString(),
        'createdAt':moment(t.createdAt).format('YYYY-MM-DD'),
        'finishedAt': moment(t.finishedAt).format('YYYY-MM-DD'),
      });
    }
  }

  setUpValidation () {
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
    if (control && control.value && !(moment(control.value, 'MM/DD/YYYY', true).isValid() || moment(control.value, 'YYYY-MM-DD', true).isValid())) {
      return { 'dateVaidator': true };
    }
    return null;
  }
}
