import { NgModule } from '@angular/core';
import { TeachersPageComponent } from './teachers-page/teachers.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';
import { TeacherProfilePageComponent } from './teacher-profile-page/teacher-profile-page.component';
import { TeachersRoutingModule } from './teachers-routing.module';

@NgModule({
  declarations: [TeachersPageComponent, TeacherProfilePageComponent],
  imports: [
    TeachersRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
  ],
})
export class TeachersModule {}
