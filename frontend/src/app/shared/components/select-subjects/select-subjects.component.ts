import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StudentService } from '@core/services/student.service';
import { SubjectsService } from '@core/services/subjects.service';
import { ISelectSubjectModal } from 'src/app/models/IModal';
import { IPinToSubject } from 'src/app/models/IStudentSubject';
import { ISubject } from 'src/app/models/ISubject';

@Component({
  selector: 'app-select-subjects',
  templateUrl: 'select-subjects.component.html',
  styleUrls: ['select-subjects.component.scss'],
})
export class SelectSubjectComponent {
  subjects: ISubject[];
  subject: string = '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: ISelectSubjectModal,
    subjectService: SubjectsService,
    private studentService: StudentService,
  ) {
    subjectService.getAllSubjects({}).subscribe((res) => {
      if (res.value) this.subjects = res.value;
    });
  }

  public confirm() {
    const pinStudent: IPinToSubject = {
        email: this.data.userEmail,
        subjectId: this.subject,
    }
    
    this.studentService.pinStudentToSubject(pinStudent).subscribe();
  }
}
