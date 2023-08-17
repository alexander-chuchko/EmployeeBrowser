import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamsListComponent } from '../components/teams/teams-list/teams-list.component';
import { TeamsCreateComponent } from '../components/teams/teams-create/teams-create.component';
import { TeamsUpdateComponent } from '../components/teams/teams-update/teams-update.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    TeamsListComponent,
    TeamsCreateComponent,
    TeamsUpdateComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatButtonModule,
  ]
})
export class TeamsModule { }
