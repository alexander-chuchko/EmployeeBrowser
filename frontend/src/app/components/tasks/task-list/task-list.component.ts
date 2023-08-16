import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Task } from 'src/app/models/task/task';
import { TasksService } from 'src/app/services/taskservice.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent {
  tasks?: Task[];
  task?: Task;

  states: any[] = [
    { value: 0, viewValue: 'To Do' },
    { value: 1, viewValue: 'In Progress' },
    { value: 2, viewValue: 'Done' },
    { value: 3, viewValue: 'Canceled' },
  ];

  constructor(private taskService: TasksService, private router: Router) {

  }

  getStateViewValue(stateValue: number): string {
    const state = this.states.find(s => s.value === stateValue);
    return state ? state.viewValue : ''; 
  }

  loadTasks() {
    this.taskService.getTasks().subscribe(data => {
      this.tasks = data;
    });
  }

  updateTask(t: Task) {
    this.task = t;
    if(t) {
      this.router.navigate(['/tasks/update', t.id]
      );
    }
  }

  deleteTask(t: Task) {
    if (t && t.id) {
      this.taskService.deleteTask(t.id).subscribe(() => {
        this.loadTasks();
      });
    }
  }

  addTask() {
    this.router.navigate(['/tasks/create']);
  }

  ngOnInit() {
    this.loadTasks();
  }
}
