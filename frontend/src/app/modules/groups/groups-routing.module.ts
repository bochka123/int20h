import {RouterModule, Routes} from "@angular/router";
import {GroupsComponent} from "@modules/groups/groups.component";
import {NgModule} from "@angular/core";

const routes: Routes = [
  {
    path: '',
    component: GroupsComponent,
    pathMatch: 'prefix'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupsRoutingModule {}
