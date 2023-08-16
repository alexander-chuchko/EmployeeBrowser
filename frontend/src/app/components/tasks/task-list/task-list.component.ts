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

  constructor(private taskService: TasksService, private router: Router) {

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
