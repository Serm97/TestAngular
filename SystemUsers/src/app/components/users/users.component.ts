import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[];

  constructor(private service: UsersService) { }

  ngOnInit() {
    this.service.getUsers().subscribe(
      next => this.users = next
    )
  }

  deleteUser(id: number) {
    alert(id);
    if (confirm('Delete this user?')) {
      this.service.deleteUser(id).subscribe(
        () => this.users = this.users.filter(f => f.id != id)
      )
    }
  }


}
