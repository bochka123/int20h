import { Component } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {IGroup} from "../../../models/IGroup";
import {GroupsService} from "@core/services/groups.service";
import {ModalComponent} from "@shared/components/modal/modal.component";

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['../create-group-subject.styles.scss']
})
export class CreateGroupComponent {
  createGroupForm = new FormGroup({
    groupName: new FormControl(''),
    mentorEmail: new FormControl('')
  });

  group: IGroup = {
    name: '',
    mentorEmail: ''
  };

  constructor(
    private groupService: GroupsService,
    private dialog: MatDialog
  ) {}
  submitForm(event: SubmitEvent) {
    event.preventDefault();
    this.createGroup();
  }

  private createGroup() {
    this.group.name = this.groupName.value;
    this.group.mentorEmail = this.mentorEmail.value;

    this.groupService.createGroup(this.group).subscribe(
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
    return this.createGroupForm.get('groupName') as FormControl;
  }

  get mentorEmail(): FormControl {
    return this.createGroupForm.get('mentorEmail') as FormControl;
  }
}
