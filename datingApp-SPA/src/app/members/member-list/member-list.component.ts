import { Component, OnInit } from '@angular/core';

import { AlertifyService } from '../../_sevices/alertify.service';
import { UserService } from '../../_sevices/user.service';
import { User } from '../../_models/user';
import { Route, ActivatedRoute } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
users: User[];

  constructor(private userService: UserService,
    private Aertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data['users'];
    });
  }
}
