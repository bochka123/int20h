import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
  emailFormatRegex,
  mobilePhoneFormatRegex,
  nameFormatRegex,
} from '@core/utils/regex.util';
import { IUser } from '../../../models/IUser';
import { UserService } from '@core/services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '@core/services/auth.service';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { ActivatedRoute, Route } from '@angular/router';
import { IStudentInformation } from 'src/app/models/IStudentInformation';
import { StudentService } from '@core/services/student.service';

@Component({
  selector: 'app-student-profile-page',
  templateUrl: 'student-profile-page.component.html',
  styleUrls: ['student-profile-page.component.scss'],
})
export class StudentProfilePageComponent {
  student: IStudentInformation;

  firstNameError: string;
  lastNameError: string;
  emailError: string;
  mobilePhoneError: string;

  updateForm = new FormGroup({
    email: new FormControl('', {
      validators: [
        Validators.required,
        Validators.maxLength(50),
        Validators.pattern(emailFormatRegex),
      ],
      updateOn: 'submit',
    }),
    firstName: new FormControl('', {
      validators: [Validators.required, Validators.pattern(nameFormatRegex)],
      updateOn: 'submit',
    }),
    lastName: new FormControl('', {
      validators: [Validators.required, Validators.pattern(nameFormatRegex)],
      updateOn: 'submit',
    }),
    mobilePhone: new FormControl('', {
      validators: [
        Validators.required,
        Validators.pattern(mobilePhoneFormatRegex),
      ],
      updateOn: 'submit',
    }),
  });

  avatarUrl: string;

  user: IUser = {
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    avatarUrl: '',
  };

  constructor(
    private userService: UserService,
    private dialog: MatDialog,
    private authService: AuthService,
    private route: ActivatedRoute,
    private studentService: StudentService
  ) {
    route.params.subscribe((params) => {
      studentService.getStudentById(params['id']).subscribe((res) => {
        if (res?.value) this.student = res.value;
      });
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.studentService.getStudentById(params['id']).subscribe((res) => {
        if (res?.value) this.student = res.value;
        this.user.firstName = res?.value?.user?.firstName || '';
        this.user.lastName = res?.value?.user?.lastName || '';
        this.user.email = res?.value?.user?.email;
        this.user.phone = res?.value?.user?.phone;
        this.user.avatarUrl = '';
        this.avatarUrl = 'assets/images/avatar/avatar.svg';
        this.updateMobilePhone(res?.value?.user?.phone);
        this.updateFirstName(res?.value?.user?.firstName);
        this.updateLastName(res?.value?.user?.lastName);
        this.updateEmail(res?.value?.user?.email);
      });
    });
  }

  submitForm(event: SubmitEvent) {
    event.preventDefault();
    this.clearErrors();

    if (!this.validateForm() || this.checkFormChanges()) {
      this.checkErrors();
      return;
    }
    this.updateProfile();
  }

  checkFormChanges(): boolean {
    return !(
      this.firstName.value !== this.user.firstName ||
      this.lastName.value !== this.user.lastName ||
      this.email.value !== this.user.email ||
      this.mobilePhone.value !== this.user.phone
    );
  }

  clearErrors() {
    this.firstNameError = '';
    this.lastNameError = '';
    this.emailError = '';
    this.mobilePhoneError = '';
  }

  private checkErrors() {
    const firstName = this.firstName.value;
    const lastName = this.lastName.value;
    const email = this.email.value;
    const mobilePhone = this.mobilePhone.value;
    const nameRegex = /^([a-zA-Z-]){2,25}$/;
    const emailRegex =
      /^([a-zA-Z-]+([a-zA-Z0-9_.]+)?)@[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*\.[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*$/;
    const mobilePhoneRegex = /^[0-9]{10}$/;
    this.firstNameError =
      firstName !== null && nameRegex.test(firstName)
        ? ''
        : 'First name must be Latin from 2 to 25 characters';
    this.lastNameError =
      lastName !== null && nameRegex.test(lastName)
        ? ''
        : 'Last name must be Latin from 2 to 25 characters';
    this.emailError = emailRegex.test(email)
      ? ''
      : 'You entered not valid email';
    this.mobilePhoneError = mobilePhoneRegex.test(mobilePhone)
      ? ''
      : 'Mobile phone must consist of 10 digits';
  }

  private validateForm() {
    return this.updateForm.valid;
  }

  private updateProfile() {
    this.user.firstName = this.firstName.value;
    this.user.lastName = this.lastName.value;
    this.user.email = this.email.value;
    this.user.phone = this.mobilePhone.value;
    this.userService.updateProfile(this.user).subscribe(
      (result: any) => {
        const dialogRef = this.dialog.open(ModalComponent, {
          data: {
            header: 'Success',
            content: (result as any).message,
          },
        });

        localStorage.setItem('user', JSON.stringify((result as any).value));

        dialogRef.afterClosed().subscribe((result: any) => {
          location.reload();
        });
      },
      (error: any) => {
        this.dialog.open(ModalComponent, {
          data: {
            header: 'Error',
            content: (error.error as any).message,
          },
        });
      }
    );
  }

  get firstName(): FormControl {
    return this.updateForm.get('firstName') as FormControl;
  }

  get lastName(): FormControl {
    return this.updateForm.get('lastName') as FormControl;
  }

  get email(): FormControl {
    return this.updateForm.get('email') as FormControl;
  }

  get mobilePhone(): FormControl {
    return this.updateForm.get('mobilePhone') as FormControl;
  }

  updateMobilePhone(mobilePhone?: string) {
    this.mobilePhone.setValue(mobilePhone);
  }

  updateFirstName(firstName?: string) {
    this.firstName.setValue(firstName);
  }

  updateLastName(lastName?: string) {
    this.lastName.setValue(lastName);
  }

  updateEmail(email?: string) {
    this.email.setValue(email);
  }

  deleteAccount() {
    const dialogRef = this.dialog.open(ModalComponent, {
      data: {
        header: 'Confirmation',
        content: 'You sure you want to delete an account?',
        hasButtons: true,
      },
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      result = result === 'true';

      if (!result) {
        return;
      }

      this.userService.deleteProfile().subscribe(
        (result: any) => {
          this.authService.logout();
          location.reload();
        },
        (error: any) => {
          this.dialog.open(ModalComponent, {
            data: {
              header: 'Error',
              content: 'Something went wrong',
            },
          });
        }
      );
    });
  }

  changeAvatar($event: Event) {
    // @ts-ignore
    const file = $event.target.files[0];

    if (file) {
      const formData = new FormData();

      formData.append(file.name, file, `/${file.name}`);

      this.userService.sendImage(formData).subscribe(
        (result: any) => {
          localStorage.setItem('user', JSON.stringify((result as any).value));
          location.reload();
        },
        (error: any) => {
          console.log(error);
        }
      );
    }
  }

  deletePhoto() {
    const model = {
      Url: this.avatarUrl,
    };

    this.userService.deleteProfilePhoto(JSON.stringify(model)).subscribe(
      (result: any) => {
        localStorage.setItem('user', JSON.stringify((result as any).value));
        location.reload();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}
