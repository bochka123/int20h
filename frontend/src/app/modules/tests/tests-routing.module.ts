import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestsPageComponent } from './tests.component';
import { AuthGuard } from '@core/guards/auth.guard';
import { RoleGuard } from '@core/guards/role.guard';
import { Role } from '@shared/data/roles';
import {TestFromComponent} from "@modules/tests/test-from/test-from.component";

const routes: Routes = [
  {
    path: '',
    component: TestsPageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.student, Role.teacher, Role.admin] }
  },
  {
    path: 'test',
    component: TestFromComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.student, Role.teacher, Role.admin] }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestsRoutingModule {}
