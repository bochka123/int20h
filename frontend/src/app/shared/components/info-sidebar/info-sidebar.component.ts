import { Component, Input, OnInit } from '@angular/core';
import { IUserSidebarInfo, userSidebarInfo } from '@core/constants/user-sidebar-info';
import { AuthService } from '@core/services/auth.service';
import { Role } from '@shared/data/roles';

@Component({
  selector: 'app-info-sidebar',
  templateUrl: 'info-sidebar.component.html',
  styleUrls: ['info-sidebar.component.scss'],
})
export class InfoSidebar implements OnInit {
  userRole: Role;
  sidebarInfoItems: IUserSidebarInfo[];

  constructor(authService: AuthService) {
    this.userRole = authService.getUserRole();
  }

  ngOnInit(): void {
    this.sidebarInfoItems = userSidebarInfo.filter(item => item.availableRoles.includes(this.userRole));
  }
}
