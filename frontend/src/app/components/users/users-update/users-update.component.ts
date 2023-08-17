import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { User } from 'src/app/models/user/user';
import { UserService } from 'src/app/services/userservice.service';

@Component({
  selector: 'app-users-update',
  templateUrl: './users-update.component.html',
  styleUrls: ['./users-update.component.css']
})
export class UsersUpdateComponent implements OnInit {
  @Input() user: User = {} as User;

  userForm!: FormGroup;
  id!: number;

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }


  onSubmit() {
    if (this.userForm.valid) {
      let newUser: User = {
        id: 0,
        teamId: this.userForm.value.teamId,
        firstName: this.userForm.value.firstName,
        lastName: this.userForm.value.lastName,
        email: this.userForm.value.email,
        registeredAt: moment(this.userForm.value.registeredAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
        birthDay: moment(this.userForm.value.birthDay, 'MM/DD/YYYY').format('YYYY-MM-DD'),
      };

      const getId = this.route.snapshot.paramMap.get('id');
      if(getId) {
          newUser.id = parseInt(getId);
      }

      this.userService.updateUser(newUser).subscribe(
        (response) => {
          console.log('User saved successfully:', response);
          this.router.navigate(['/users']);
        },
        (error) => {
          console.error('Error saving user:', error);
        }
      );
    }
  }

  ngOnInit(): void {
    this.setUpValidation();
    this.route.params.subscribe(params => {
      const userId = +params['id'];
      this.userService.getUser(userId).subscribe(user => {
        this.initializingFieldsWithValues(user);
      });
    });
  }

  setUpValidation () {
    this.userForm = new FormGroup({
      'teamId': new FormControl(this.user.teamId, [
        Validators.required,
        this.validateId
      ]),
      'firstName': new FormControl(this.user.firstName, [
        Validators.required,
        Validators.minLength(3)
      ]),
      'lastName': new FormControl(this.user.teamId, [
        Validators.required,
        Validators.minLength(3)
        
      ]),
      'email': new FormControl(this.user.email, [
        Validators.required,
        Validators.email
      ]),
      'registeredAt': new FormControl(this.user.registeredAt, [
        Validators.required,
        this.dateVaidator
      ]),
      'birthDay': new FormControl(this.user.birthDay, [
        Validators.required,
        this.dateVaidator
      ]),
    });
  }

  initializingFieldsWithValues(u: User) {
    if (u) {
      this.userForm.patchValue({
        'teamId': u?.teamId,
        'firstName': u?.firstName,
        'lastName': u?.lastName,
        'email': u?.email,
        'registeredAt':moment(u.registeredAt).format('YYYY-MM-DD'),
        'birthDay': moment(u.birthDay).format('YYYY-MM-DD'),
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
