import { Component } from '@angular/core';
import { SecurityService } from './services/security.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SystemUsers';

  log : SecurityService;

  logout(){
    this.log.logout();
  }


}
