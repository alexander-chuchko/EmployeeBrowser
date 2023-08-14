import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project/project';
import { DataService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-projects-details',
  templateUrl: './projects-details.component.html',
  styleUrls: ['./projects-details.component.css']
})

export class ProjectsDetailsComponent implements OnInit {
  projects?: Project[];
  project?: Project;

  constructor(private dataService: DataService) {

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

  }

  ngOnInit() {
    this.loadPojects();
  }
}
