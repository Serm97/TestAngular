import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SecurityService } from './services/security.service';
import { UsersComponent } from './components/users/users.component';
import { UserComponent } from './components/user/user.component';
import { HttpRequestInterceptor, HttpInterceptorModule } from './services/http-interceptor.module';
import { UsersService } from './services/users.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    UsersComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    HttpInterceptorModule
  ],
  providers: [ SecurityService, UsersService],
  bootstrap: [AppComponent]
})
export class AppModule {  }
