import {RouterModule, Routes} from "@angular/router";
import {GroupsComponent} from "@modules/groups/groups.component";
import {NgModule} from "@angular/core";
import {CreateSubjectComponent} from "@modules/groups/create-subject/create-subject.component";
import {CreateGroupComponent} from "@modules/groups/create-group/create-group.component";

const routes: Routes = [
  {
    path: '',
    component: GroupsComponent,
    pathMatch: 'prefix'
  },
  {
    path: 'create-subject',
    component: CreateSubjectComponent,
    pathMatch: 'prefix'
  },
  {
    path: 'create-group',
    component: CreateGroupComponent,
    pathMatch: 'prefix'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupsRoutingModule {}
