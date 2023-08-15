import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from 'src/app/models/project/project';
import { DataService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.css']
})

export class ProjectsListComponent implements OnInit {
  projects?: Project[];
  project?: Project;

  constructor(private dataService: DataService, private router: Router) {

  }

  loadPojects() {
    this.dataService.getProjects().subscribe(data => {
      this.projects = data;
    });
  }

  editProject(p: Project) {
    this.project = p;
  }

  delete(p: Project) {

  }

  addProject() {
    this.router.navigate(['/projects/create']);
  }

  ngOnInit() {
    this.loadPojects();
  }
}
