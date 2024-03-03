import { Component, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss'],
})
export class MainComponent {
    public isAuthenticated:boolean;

    constructor(authService: AuthService) {
      authService.isAuthenticated().subscribe(res => this.isAuthenticated = res);
    }
}
