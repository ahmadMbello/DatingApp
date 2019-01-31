import { Injectable } from '@angular/core';
import { Resolve, ActivatedRoute, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_sevices/user.service';
import { AlertifyService } from '../_sevices/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

export class MembersListResolver implements Resolve<User[]> {
   constructor(private userService: UserService, private alertify: AlertifyService,
     private router: Router ) {}
     resolve(): Observable<User[]> {
         return this.userService.getUsers().pipe(
             catchError(error => {this.alertify.error('problem retriving data');
            this.router.navigate(['/home']);
        return of(null);
        })
         );
     }
}

