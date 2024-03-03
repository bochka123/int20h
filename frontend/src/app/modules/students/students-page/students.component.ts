import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '@core/services/student.service';
import { SubjectsService } from '@core/services/subjects.service';
import { UserService } from '@core/services/user.service';
import { HeaderComponent } from '@shared/components/header/header.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { SelectSubjectComponent } from '@shared/components/select-subjects/select-subjects.component';
import { IStudentInformation } from 'src/app/models/IStudentInformation';
import { ISubject } from 'src/app/models/ISubject';

@Component({
  selector: 'app-students-page',
  templateUrl: 'students.component.html',
  styleUrls: ['students.component.scss'],
})
export class StudentsPageComponent {
  students: IStudentInformation[];
  showNotVerified: boolean = false;
  subjects: ISubject[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private studentService: StudentService,
    private dialog: MatDialog,
    subjectService: SubjectsService
  ) {
    studentService.getAllStudents().subscribe((res) => {
      if (res?.value) this.students = res.value;
    });

    subjectService.getAllSubjects({}).subscribe((res) => {
      if (res.value) this.subjects = res.value;
    });
  }

  public Verify(id?: string) {
    const student = this.students.find((s) => s.id == id);

    this.userService
      .confirmUserRole({ email: student?.user?.email || '' })
      .subscribe();

    if (this.showNotVerified)
      this.studentService.getNotVerifiedStudents().subscribe((res) => {
        if (res?.value) this.students = res.value;
      });
    else
      this.studentService.getAllStudents().subscribe((res) => {
        if (res?.value) this.students = res.value;
      });
  }

  public Deny(id?: string) {}

  public onCheckboxChange() {
    if (this.showNotVerified)
      this.studentService.getNotVerifiedStudents().subscribe((res) => {
        if (res?.value) this.students = res.value;
      });
    else
      this.studentService.getAllStudents().subscribe((res) => {
        if (res?.value) this.students = res.value;
      });
  }

  public NavigateToStudentPage(e: MouseEvent, id?: string) {
    if (
      (e.target as HTMLElement).tagName.toLowerCase() !== 'button' &&
      (e.target as HTMLElement).tagName.toLowerCase() !== 'img'
    ) {
      this.router.navigate([`${id}`], { relativeTo: this.route });
    }
  }

  public AddSubjects(id?: string) {

    const student = this.students.find(s => s.id == id);

    this.dialog.open(SelectSubjectComponent, {
      data: {
        header: 'Add to subject',
        userEmail: student?.user?.email,
        hasButtons: true,
      },
    });
  }
}
