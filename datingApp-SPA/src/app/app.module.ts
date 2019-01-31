import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_sevices/Auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorTnterceptorProvider } from './_sevices/Error.Interceptor';
import { AlertifyService } from './_sevices/alertify.service';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AuthGuard } from './_guard/auth.guard';
import { UserService } from './_sevices/user.service';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MembersDetailsComponent } from './members/members-details/members-details.component';
import { MemeberDatailsResolver } from './_resolvers/member-details.reslovers';
import { MembersListResolver } from './_resolvers/member-List.reslovers.';
import { NgxGalleryModule } from 'ngx-gallery';

export function tokenGetter() {
return localStorage.getItem('token');
}





@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
      MemberListComponent,
      MemberCardComponent,
      MembersDetailsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      NgxGalleryModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:500/api/auth']
         }
      }),
   ],
   providers: [
      AuthService,
      ErrorTnterceptorProvider,
      AlertifyService,
      AuthGuard,
      UserService,
      MemeberDatailsResolver,
      MembersListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
