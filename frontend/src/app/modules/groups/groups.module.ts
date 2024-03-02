import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsComponent } from './groups.component';
import {GroupsRoutingModule} from "@modules/groups/groups-routing.module";
import { CreateGroupComponent } from './create-group/create-group.component';
import { CreateSubjectComponent } from './create-subject/create-subject.component';
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    GroupsComponent,
    CreateGroupComponent,
    CreateSubjectComponent
  ],
  imports: [
    CommonModule, GroupsRoutingModule, ReactiveFormsModule
  ]
})
export class GroupsModule { }
