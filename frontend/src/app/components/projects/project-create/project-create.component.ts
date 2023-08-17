import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { Project } from 'src/app/models/project/project';
import { DataService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-project-create',
  templateUrl: './project-create.component.html',
  styleUrls: ['./project-create.component.css'],
})
export class ProjectCreateComponent implements OnInit {
  @Input() project: Project = {} as Project;
  @Output() projectChange = new EventEmitter<Project>();

  projectForm!: FormGroup;

  constructor(private dataService: DataService, private router: Router) { }

  onSubmit() {  
    if (this.projectForm.valid) {
      const newProject: Project = {
        id: 0,
        name: this.projectForm.value.name,
        userId: this.projectForm.value.userId,
        teamId: this.projectForm.value.teamId,
        description: this.projectForm.value.description,
        createdAt: moment(this.projectForm.value.createdAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
        deadline: moment(this.projectForm.value.deadline, 'MM/DD/YYYY').format('YYYY-MM-DD'),
      };


      this.dataService.createProject(newProject).subscribe(
        (response: Project) => {
          console.log('Project saved successfully:', response);
          this.router.navigate(['/projects']);
        },
        (error: Project) => {
          console.error('Error saving project:', error);
        }
      );
    }
  }

  ngOnInit(): void {
    this.projectForm = new FormGroup({
      'name': new FormControl(this.project.name, [
        Validators.required,
        Validators.minLength(3)
      ]),
      'userId': new FormControl(this.project.userId, [
        Validators.required,
        this.validateId
      ]),
      'teamId': new FormControl(this.project.teamId, [
        Validators.required,
        this.validateId
      ]),
      'description': new FormControl(this.project.description, [
        Validators.required,
        Validators.minLength(20)
      ]),
      'createdAt': new FormControl(this.project.createdAt, [
        Validators.required,
        this.dateVaidator
      ]),
      'deadline': new FormControl(this.project.deadline, [
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



