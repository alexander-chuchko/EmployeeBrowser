import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Project } from 'src/app/models/project/project';

@Component({
  selector: 'app-project-create',
  templateUrl: './project-create.component.html',
  styleUrls: ['./project-create.component.css']
})
export class ProjectCreateComponent implements OnInit {
  @Input() project: Project = {} as Project;
  @Output() projectChange = new EventEmitter<Project>();

  projectForm!: FormGroup;

  isInputFocused = false;
  isSubmitted = false;

  constructor() { }

  onSubmit() {

  }

  ngOnInit(): void {
    this.projectForm = new FormGroup({
      'name': new FormControl(this.project.name, [
        Validators.required, Validators.minLength(3)
      ]),
      'userId': new FormControl(this.project.userId, [
        Validators.minLength(3)
      ]),
      'teamId': new FormControl(this.project.teamId, [
        Validators.minLength(3)
      ]),
      'createdAt': new FormControl(this.project.createdAt, [
        Validators.required,
      ]),
      'description': new FormControl(this.project.description, [
        Validators.required,
        Validators.minLength(20)
      ]),
      'deadline': new FormControl(this.project.deadline, [
        Validators.required,
      ]),
    });
  }
}
