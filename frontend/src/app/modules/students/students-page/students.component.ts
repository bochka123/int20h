import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '@core/services/student.service';
import { UserService } from '@core/services/user.service';
import { IStudentInformation } from 'src/app/models/IStudentInformation';

type OptionType = {
  name: string;
  isVerified: boolean;
};

@Component({
  selector: 'app-students-page',
  templateUrl: 'students.component.html',
  styleUrls: ['students.component.scss'],
})
export class StudentsPageComponent {
  students: IStudentInformation[];
  showNotVerified: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private studentService: StudentService
  ) {
    studentService.getAllStudents().subscribe((res) => {
      if (res?.value) this.students = res.value;
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
    if ((e.target as HTMLElement).tagName.toLowerCase() !== 'button') {
      this.router.navigate([`${id}`], { relativeTo: this.route });
    }
  }
}
