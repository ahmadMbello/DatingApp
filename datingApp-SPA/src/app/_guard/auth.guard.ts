import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_sevices/Auth.service';
import { AlertifyService } from '../_sevices/alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor (private authservice: AuthService, private router: Router,
     private alertify: AlertifyService ) {}
  canActivate(): boolean {
    if ( this.authservice.loggedin()) {

      return true;

    } else {
this.alertify.error('you can not pass>>');
this.router.navigate(['/home']);
return false;
    }
  }
}
