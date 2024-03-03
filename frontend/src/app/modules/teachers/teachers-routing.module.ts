import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';
import { RoleGuard } from '@core/guards/role.guard';
import { Role } from '@shared/data/roles';
import { TeachersPageComponent } from './teachers-page/teachers.component';
import { TeacherProfilePageComponent } from './teacher-profile-page/teacher-profile-page.component';

const routes: Routes = [
  {
    path: '',
    component: TeachersPageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.teacher, Role.admin] }
  },
  {
    path: ':id',
    component: TeacherProfilePageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.teacher, Role.admin] }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeachersRoutingModule {}
