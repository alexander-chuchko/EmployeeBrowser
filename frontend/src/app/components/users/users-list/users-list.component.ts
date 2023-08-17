import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user/user';
import { UserService } from 'src/app/services/userservice.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  users?: User[];
  user?: User;

  constructor(private userService: UserService, private router: Router) { }

  loadUsers() {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    });
  }

  updateUser(u: User) {
    this.user = u;
    if(u) {
      this.router.navigate(['/users/update', u.id],
      );
    }
  }

  deleteUser(u: User) {
    if (u && u.id) {
      this.userService.deleteUser(u.id).subscribe(() => {
        this.loadUsers();
      });
    }
  }

  addUser() {
    this.router.navigate(['/users/create']);
  }

  ngOnInit() {
    this.loadUsers();
  }
}
