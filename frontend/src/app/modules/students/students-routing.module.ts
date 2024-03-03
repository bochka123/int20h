import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsPageComponent } from './students-page/students.component';
import { AuthGuard } from '@core/guards/auth.guard';
import { RoleGuard } from '@core/guards/role.guard';
import { Role } from '@shared/data/roles';
import {StudentProfilePageComponent} from "@modules/students/student-profile-page/student-profile-page.component";

const routes: Routes = [
  {
    path: '',
    component: StudentsPageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.teacher, Role.admin] }
  },
  {
    path: ':id',
    component: StudentProfilePageComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: [Role.teacher, Role.admin] }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StudentsRoutingModule {}
