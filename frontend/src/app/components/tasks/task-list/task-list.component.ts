import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Task } from 'src/app/models/task/task';
import { DataService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent {
  tasks?: Task[];
  task?: Task;

  constructor(private dataService: DataService, private router: Router) {

  }

  loadPojects() {
   // this.dataService..subscribe(data => {
      //this.tasks = data;
    //});
  }

  updateProject(t: Task) {
    this.task = t;
    if(t) {
      this.router.navigate(['/projects/update', t.id]
      );
    }
  }

  deleteProject(t: Task) {
    if (t && t.id) {
      this.dataService.deleteProject(t.id).subscribe(() => {
        this.loadPojects();
      });
    }
  }

  addProject() {
    this.router.navigate(['/projects/create']);
  }

  ngOnInit() {
    this.loadPojects();
  }
}
