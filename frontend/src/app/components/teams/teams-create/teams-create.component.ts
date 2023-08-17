import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { Team } from 'src/app/models/team/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams-create',
  templateUrl: './teams-create.component.html',
  styleUrls: ['./teams-create.component.css']
})
export class TeamsCreateComponent implements OnInit {
  @Input() team: Team = {} as Team;
  teamForm!: FormGroup;

  constructor(private teamService: TeamService, private router: Router) { }

  ngOnInit(): void {
    this.teamForm = new FormGroup({
      'name': new FormControl(this.team.name, [
        Validators.required,
        Validators.minLength(3)
      ]),
      'createdAt': new FormControl(this.team.createdAt, [
        Validators.required,
        this.dateVaidator
      ]),
    });
  }

  onSubmit() {  
    if (this.teamForm.valid) {
      const newTeam: Team = {
        id: 0,
        name: this.teamForm.value.name,
        createdAt: moment(this.teamForm.value.createdAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
      };


      this.teamService.createTeam(newTeam).subscribe(
        (response: Team) => {
          console.log('Team saved successfully:', response);
          this.router.navigate(['/teams']);
        },
        (error: Team) => {
          console.error('Error saving team:', error);
        }
      );
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
    if (control && control.value && !moment(control.value, 'MM/DD/YYYY', true).isValid()) {
      return { 'dateVaidator': true };
    }
    return null;
  }

}
