import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { User } from 'src/app/models/user/user';
import { UserService } from 'src/app/services/userservice.service';

@Component({
  selector: 'app-users-create',
  templateUrl: './users-create.component.html',
  styleUrls: ['./users-create.component.css']
})
export class UsersCreateComponent implements OnInit {
  @Input() user: User = {} as User;

  userForm!: FormGroup;

  constructor(private userService: UserService, private router: Router) { }

  onSubmit() {  
    if (this.userForm.valid) {
      const newUser: User = {
        id: 0,
        teamId: this.userForm.value.teamId,
        firstName: this.userForm.value.firstName,
        lastName: this.userForm.value.lastName,
        email: this.userForm.value.email,
        registeredAt: moment(this.userForm.value.registeredAt, 'MM/DD/YYYY').format('YYYY-MM-DD'),
        birthDay: moment(this.userForm.value.birthDay, 'MM/DD/YYYY').format('YYYY-MM-DD'),
      };

      this.userService.createUser(newUser).subscribe(
        (response: User) => {
          console.log('User saved successfully:', response);
          this.router.navigate(['/users']);
        },
        (error: User) => {
          console.error('Error saving user:', error);
        }
      );
    }
  }

  ngOnInit(): void {
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
