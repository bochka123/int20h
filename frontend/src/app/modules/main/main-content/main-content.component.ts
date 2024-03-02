import { Component } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { Role } from '@shared/data/roles';

@Component({
    selector: 'app-main-content',
    templateUrl: './main-content.component.html',
    styleUrls: ['./main-content.component.scss'],
})
export class MainContentComponent {
  public isAuthenticated: boolean;

  constructor(authService: AuthService) {
      authService.isAuthenticated().subscribe(res => this.isAuthenticated = res);
  }
}
