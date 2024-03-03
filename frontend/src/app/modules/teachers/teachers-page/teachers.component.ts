import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '@core/services/student.service';
import { SubjectsService } from '@core/services/subjects.service';
import { TeacherService } from '@core/services/teacher.service';
import { UserService } from '@core/services/user.service';
import { HeaderComponent } from '@shared/components/header/header.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { SelectSubjectComponent } from '@shared/components/select-subjects/select-subjects.component';
import { IStudentInformation } from 'src/app/models/IStudentInformation';
import { ISubject } from 'src/app/models/ISubject';
import { ITeacherInformation } from 'src/app/models/ITeacherInformation';

@Component({
  selector: 'app-students-page',
  templateUrl: 'teachers.component.html',
  styleUrls: ['teachers.component.scss'],
})
export class TeachersPageComponent {
  teachers: ITeacherInformation[];
  showNotVerified: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private teacherService: TeacherService,
  ) {
    teacherService.getAllTeachers().subscribe((res) => {
      if (res?.value) this.teachers = res.value;
    });
  }

  public Verify(id?: string) {
    const teacher = this.teachers.find((s) => s.id == id);

    this.userService
      .confirmUserRole({ email: teacher?.user?.email || '' })
      .subscribe();

    if (this.showNotVerified)
      this.teacherService.getNotVerifiedTeachers().subscribe((res) => {
        if (res?.value) this.teachers = res.value;
      });
    else
      this.teacherService.getAllTeachers().subscribe((res) => {
        if (res?.value) this.teachers = res.value;
      });
  }

  public Deny(id?: string) {}

  public onCheckboxChange() {
    if (this.showNotVerified)
      this.teacherService.getNotVerifiedTeachers().subscribe((res) => {
        if (res?.value) this.teachers = res.value;
      });
    else
      this.teacherService.getAllTeachers().subscribe((res) => {
        if (res?.value) this.teachers = res.value;
      });
  }

  public NavigateToTeacherPage(e: MouseEvent, id?: string) {
    if (
      (e.target as HTMLElement).tagName.toLowerCase() !== 'button' &&
      (e.target as HTMLElement).tagName.toLowerCase() !== 'img'
    ) {
      this.router.navigate([`${id}`], { relativeTo: this.route });
    }
  }
}
