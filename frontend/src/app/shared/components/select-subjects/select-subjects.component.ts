import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubjectsService } from '@core/services/subjects.service';
import { IModal, ISelectSubjectModal } from 'src/app/models/IModal';
import { ISubject } from 'src/app/models/ISubject';

@Component({
  selector: 'app-select-subjects',
  templateUrl: 'select-subjects.component.html',
  styleUrls: ['select-subjects.component.scss'],
})
export class SelectSubjectComponent {
  subjects: ISubject[];
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: ISelectSubjectModal,
    subjectService: SubjectsService
  ) {
    subjectService.getAllSubjects({}).subscribe((res) => {
      if (res.value) this.subjects = res.value;
    });
  }
  //   constructor(
  //     // private router: Router,
  //     // private route: ActivatedRoute,
  //     // private userService: UserService,
  //     // private studentService: StudentService,
  //     // private dialog: MatDialog,
  //     subjectService: SubjectsService
  //   ) {
  //     // studentService.getAllStudents().subscribe((res) => {
  //     //   if (res?.value) this.students = res.value;
  //     // });

  //     subjectService.getAllSubjects({}).subscribe((res) => {
  //       if (res.value) this.subjects = res.value;
  //     });
  //   }

  public confirm() {

  }
}
