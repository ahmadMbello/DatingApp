import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_sevices/Auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor(private authservice: AuthService) { }

  ngOnInit() {
  }
  login() {

  this.authservice.login(this.model).subscribe( next => {
      console.log('logging in success');
    }, (error: any) => {
console.log('logging failed');
    }
    );
  }


  LoggedIn() {
    const token = localStorage.getItem('token');
return !!token;
  }


  loggedout() {
localStorage.removeItem('token');
console.log('logged out');
  }

}
