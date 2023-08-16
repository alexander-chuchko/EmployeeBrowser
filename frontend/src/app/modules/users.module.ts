import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersListComponent } from '../components/users/users-list/users-list.component';
import { UsersCreateComponent } from '../components/users/users-create/users-create.component';
import { UsersUpdateComponent } from '../components/users/users-update/users-update.component';


@NgModule({
  declarations: [
    UsersListComponent,
    UsersCreateComponent,
    UsersUpdateComponent

  ],
  imports: [
    CommonModule
  ]
})
export class UsersModule { }
