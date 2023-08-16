import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamsListComponent } from '../components/teams/teams-list/teams-list.component';
import { TeamsCreateComponent } from '../components/teams/teams-create/teams-create.component';
import { TeamsUpdateComponent } from '../components/teams/teams-update/teams-update.component';


@NgModule({
  declarations: [
    TeamsListComponent,
    TeamsCreateComponent,
    TeamsUpdateComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TeamsModule { }
