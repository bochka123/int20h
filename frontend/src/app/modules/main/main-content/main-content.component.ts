import { Component, OnInit } from '@angular/core';
import {AuthService} from "@core/services/auth.service";

@Component({
    selector: 'app-main-content',
    templateUrl: './main-content.component.html',
    styleUrls: ['./main-content.component.scss'],
})
export class MainContentComponent{

  public isAuthenticated:boolean;

  constructor(private authService:AuthService) {
    authService.isAuthenticated().subscribe(res => this.isAuthenticated = res);
  }

}
