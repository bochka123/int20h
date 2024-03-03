import {Component, OnInit} from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import {GroupsService} from "@core/services/groups.service";
import { IGroup } from 'src/app/models/IGroup';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupsComponent implements OnInit {

  availableGroups: IGroup[];

  constructor(private groupService: GroupsService, authService: AuthService) {
    groupService.getUserGroups({ userEmail: authService.getUserEmail() }).subscribe(res => { if(res.value) this.availableGroups = res.value; });
  }

  ngOnInit(): void {
  }

}
