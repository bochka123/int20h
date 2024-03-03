import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestsPageComponent } from './tests.component';
import { AuthGuard } from '@core/guards/auth.guard';
import { RoleGuard } from '@core/guards/role.guard';
import { Role } from '@shared/data/roles';
import {TestFromComponent} from "@modules/tests/test-from/test-from.component";
import { CreatePageComponent } from './create-page/create-page.component';
import { CreateTasksPageComponent } from './create-tasks-page/create-tasks-page.component';

const routes: Routes = [
  {
    path: '',
    component: TestsPageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.student, Role.teacher, Role.admin] }
  },
  {
    path: 'pass-test/:id',
    component: TestFromComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.student, Role.teacher, Role.admin] }
  },
  {
    path: 'create',
    component: CreatePageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {roles: [Role.teacher]}
  },
  {
    path: 'test/:id',
    component: CreateTasksPageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {roles: [Role.teacher]}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestsRoutingModule {}
