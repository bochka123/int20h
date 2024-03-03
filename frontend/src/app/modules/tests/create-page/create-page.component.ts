import {Component, OnInit} from '@angular/core';
import {ICreateTest} from "../../../models/ICreateTest";
import {IQuestionDto, IQuestionOptionDto} from "../../../models/IQuestionDto";
import {GroupsService} from "@core/services/groups.service";
import {IGroup} from "../../../models/IGroup";

@Component({
  selector: 'app-create-page',
  templateUrl: './create-page.component.html',
  styleUrls: ['./create-page.component.scss']
})
export class CreatePageComponent implements OnInit{
  test: ICreateTest = { title: '', description: '', cost: 0, groupName: '' };
  groups: string[] = [];
  constructor( private groupService: GroupsService) {
  }

  ngOnInit(): void {
    this.groupService.getAllGroups({}).subscribe((res) => {
      const groupsArray: IGroup[] = res.value as IGroup[];
      this.groups = groupsArray.map((group) => group.name || '');

    });
  }

  createTest(): void {

  }
}
