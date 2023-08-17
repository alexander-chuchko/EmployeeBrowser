import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Team } from 'src/app/models/team/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent implements OnInit {
  teams?: Team[];
  team?: Team;

  constructor(private teamService: TeamService, private router: Router) { }

  loadTeams() {
    this.teamService.getTeams().subscribe(data => {
      this.teams = data;
    });
  }

    updateTeam(t: Team) {
      this.team = t;
      if(t) {
        this.router.navigate(['/teams/update', t.id],
        );
      }
    }
  
    deleteProject(t: Team) {
      if (t && t.id) {
        this.teamService.deleteTeam(t.id).subscribe(() => {
          this.loadTeams();
        });
      }
    }
  
    addProject() {
      this.router.navigate(['/teams/create']);
    }

    ngOnInit(): void {
      this.loadTeams();
    }
  }

