import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_sevices/Auth.service';
import { error } from 'util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() CancelRegister = new EventEmitter();
model: any = {};
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }
  register() {
this.authService.register(this.model).subscribe(() => {
  console.log('registration successful');
}, Error => {
  console.log(error);
});
  }

  cancel() {
    this.CancelRegister.emit(false);
console.log('Register Caneled');

  }


}
