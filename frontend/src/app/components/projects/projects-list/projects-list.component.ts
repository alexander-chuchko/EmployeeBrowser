import { Component, OnInit, Output } from '@angular/core';
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
  @Output() idEmmiter?: number;

  constructor(private dataService: DataService, private router: Router) {

  }

  loadPojects() {
    this.dataService.getProjects().subscribe(data => {
      this.projects = data;
    });
  }

  updateProject(p: Project) {
    this.project = p;
    if(p) {
      this.router.navigate(['/projects/update', p.id]
      );
    }
  }

  deleteProject(p: Project) {
    if (p && p.id) {
      this.dataService.deleteProject(p.id).subscribe(() => {
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
