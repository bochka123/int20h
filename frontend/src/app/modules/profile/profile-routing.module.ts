import {RouterModule, Routes} from "@angular/router";
import {ProfileComponent} from "@modules/profile/profile.component";
import {NgModule} from "@angular/core";

const routes: Routes = [
  {
    path: '',
    component: ProfileComponent,
    pathMatch: 'prefix'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProfileRoutingModule {}
