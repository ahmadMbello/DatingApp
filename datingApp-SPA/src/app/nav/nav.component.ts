import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_sevices/Auth.service';
import { AlertifyService } from '../_sevices/alertify.service';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';



@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor(public authservice: AuthService, private alertify: AlertifyService,
     private router: Router) { }

  ngOnInit() {
  }
  login() {

  this.authservice.login(this.model).subscribe(next => {
    this.alertify.success('logging in success');
    } ,
  error => {
    this.alertify.error(error);
    },
    () => {
this.router.navigate(['/members']);
    }
    );
  }


  LoggedIn() {
return this.authservice.loggedin();
  }


  loggedout() {
localStorage.removeItem('token');
this.alertify.message('logged out');
this.router.navigate(['/home']);
  }

}
