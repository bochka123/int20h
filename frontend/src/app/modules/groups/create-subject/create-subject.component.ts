import { Component } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {ModalComponent} from "@shared/components/modal/modal.component";
import {ISubject} from "../../../models/ISubject";
import {SubjectsService} from "@core/services/subjects.service";

@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrls: ['../create-group-subject.styles.scss']
})
export class CreateSubjectComponent {
  createSubjectForm = new FormGroup({
    subjectName: new FormControl(''),
    teacherEmail: new FormControl('')
  });

  subject: ISubject = {
    name: '',
    mainTeacherEmail: ''
  };

  constructor(
    private subjectService: SubjectsService,
    private dialog: MatDialog
  ) {}
  submitForm(event: SubmitEvent) {
    event.preventDefault();
    this.createSubject();
  }

  private createSubject() {
    this.subject.name = this.groupName.value;
    this.subject.mainTeacherEmail = this.mentorEmail.value;

    this.subjectService.createSubject(this.subject).subscribe(
      (result) => {
        this.dialog.open(ModalComponent, {
          data: {
            header: 'Success',
            content: (result as any).message,
          },
        });
      },
      (error) => {
        this.dialog.open(ModalComponent, {
          data: {
            header: 'Error',
            content: (error.error as any).message,
          },
        });
      },
    );
  }

  get groupName(): FormControl {
    return this.createSubjectForm.get('subjectName') as FormControl;
  }

  get mentorEmail(): FormControl {
    return this.createSubjectForm.get('teacherEmail') as FormControl;
  }
}
