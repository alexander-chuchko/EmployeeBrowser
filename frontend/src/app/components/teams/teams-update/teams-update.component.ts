import { Component, Input } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Team } from 'src/app/models/team/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams-update',
  templateUrl: './teams-update.component.html',
  styleUrls: ['./teams-update.component.css']
})
export class TeamsUpdateComponent {
  @Input() team: Team = {} as Team;

  teamForm!: FormGroup;
  id!: number;

  constructor(private teamService: TeamService, private router: Router, private route: ActivatedRoute) { }


  onSubmit() {
    if (this.teamForm.valid) {
      let newTeam: Team = {
        id: 0,
        name: this.teamForm.value.name,
        createdAt: moment(this.teamForm.value.createdAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
      };

      const getId = this.route.snapshot.paramMap.get('id');
      if (getId) {
        newTeam.id = parseInt(getId);
      }

      this.teamService.updateTeam(newTeam).subscribe(
        (response) => {
          console.log('Team saved successfully:', response);
          this.router.navigate(['/teams']);
        },
        (error) => {
          console.error('Error saving team:', error);
        }
      );
    }
  }

  ngOnInit(): void {
    this.setUpValidation();
    this.route.params.subscribe(params => {
      const teamId = +params['id'];
      this.teamService.getTeam(teamId).subscribe(team => {
        this.initializingFieldsWithValues(team);
      });
    });
  }

  setUpValidation() {
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

  initializingFieldsWithValues(t: Team) {
    if (t) {
      this.teamForm.patchValue({
        'name': t?.name,
        'createdAt': moment(t.createdAt).format('YYYY-MM-DD'),
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
