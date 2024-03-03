import {Component, OnInit} from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import {GroupsService} from "@core/services/groups.service";
import { SubjectsService } from '@core/services/subjects.service';
import { IGroup } from 'src/app/models/IGroup';
import { ISubject } from 'src/app/models/ISubject';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupsComponent implements OnInit {

  availableGroups: IGroup[];
  availableSubjects: ISubject[];

  constructor(groupService: GroupsService, subjectService: SubjectsService, authService: AuthService) {
    groupService.getUserGroups({ userEmail: authService.getUserEmail() }).subscribe(res => { if(res.value) this.availableGroups = res.value; });
    subjectService.getUserSubjects({ userEmail: authService.getUserEmail() }).subscribe(res => { if(res.value) this.availableSubjects = res.value; });
  }

  ngOnInit(): void {
  }

}
