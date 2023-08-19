import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Observable, of } from 'rxjs';
import { Project } from 'src/app/models/project/project';
import { ProjectService } from 'src/app/services/projectservice.service';

@Component({
  selector: 'app-project-update',
  templateUrl: './project-update.component.html',
  styleUrls: ['./project-update.component.css']
})

export class ProjectUpdateComponent implements OnInit {
  @Input() project: Project = {} as Project;

  projectForm!: FormGroup;
  id!: number;
  isSaved = false;

  constructor(private dataService: ProjectService, private router: Router, private route: ActivatedRoute) { }

  canDeactivate(): Observable<boolean> {
    if (this.projectForm.dirty && !this.isSaved) {
      const result = window.confirm('There are unsaved changes! Are you sure?');
      return of(result);
    }
    return of(true);
  }

  onSubmit() {
    this.isSaved = true;
    if (this.projectForm.valid) {
      let newProject: Project = {
        id: 0,
        name: this.projectForm.value.name,
        userId: this.projectForm.value.userId,
        teamId: this.projectForm.value.teamId,
        description: this.projectForm.value.description,
        createdAt: this.projectForm.value.createdAt,
        deadline: this.projectForm.value.deadline
      };

      const getId = this.route.snapshot.paramMap.get('id');
      if(getId) {
          newProject.id = parseInt(getId);
      }

      this.dataService.updateProject(newProject).subscribe(
        (response) => {
          console.log('Project saved successfully:', response);
          this.router.navigate(['/projects']);
        },
        (error) => {
          console.error('Error saving project:', error);
        }
      );
    }
  }

  ngOnInit(): void {
    this.setUpValidation();
    this.route.params.subscribe(params => {
      const projectId = +params['id'];
      this.dataService.getProject(projectId).subscribe(project => {
        this.initializingFieldsWithValues(project);
      });
    });
  }

  setUpValidation () {
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

  initializingFieldsWithValues(p: Project) {
    if (p) {
      this.projectForm.patchValue({
        'name': p?.name,
        'userId': p?.userId,
        'teamId': p?.teamId,
        'description': p?.description,
        'createdAt':moment(p.createdAt).format('YYYY-MM-DD'),
        'deadline': moment(p.deadline).format('YYYY-MM-DD'),
      });
    }
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
