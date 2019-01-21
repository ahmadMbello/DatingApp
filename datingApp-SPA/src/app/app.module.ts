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
import { BsDropdownModule } from 'ngx-bootstrap';




@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorTnterceptorProvider,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
