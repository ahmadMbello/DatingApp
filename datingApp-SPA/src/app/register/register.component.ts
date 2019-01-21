import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_sevices/Auth.service';
import { AlertifyService } from '../_sevices/alertify.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() CancelRegister = new EventEmitter();
model: any = {};
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  register() {
this.authService.register(this.model).subscribe(next => {
  console.log('registration successful');
}, error => {
  this.alertify.error(error);
});
  }

  cancel() {
    this.CancelRegister.emit(false);
console.log('Register Caneled');

  }


}
