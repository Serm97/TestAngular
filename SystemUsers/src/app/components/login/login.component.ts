import { Component, OnInit } from '@angular/core';
import { AppUser } from 'src/app/models/app-user';
import { AppUserAuth } from 'src/app/models/app-user-auth';
import { SecurityService } from 'src/app/services/security.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: AppUser = new AppUser();
  securityObject : AppUserAuth = null;
  returnUrl = '/home';
  errorMessage = '';

  constructor(private service: SecurityService, private router: Router) { }

  ngOnInit() {
  }

  login(){
    this.errorMessage = '';
    this.service.login(this.user).subscribe(
      res => {
        this.securityObject = res;
        this.router.navigateByUrl(this.returnUrl);
      }
    ),
    error => this.errorMessage = error;
  }

}
