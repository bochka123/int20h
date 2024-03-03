import { Component, DoCheck, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@core/services/auth.service';
import { matchpassword } from '@core/validators/matchpassword.validator';
import { emailFormatRegex, mobilePhoneFormatRegex, nameFormatRegex, passFormatRegex } from '@core/utils/regex.util';
import { ICreateUser } from '../../../models/IUser';
import { Router } from '@angular/router';
import {MatDialog} from "@angular/material/dialog";
import { RegisterRoles } from '@shared/data/register-roles';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { GroupsService } from '@core/services/groups.service';
import { IFilterResponse } from 'src/app/models/IFilterResponse';
import { IGroup } from 'src/app/models/IGroup';
import { Subscription } from 'rxjs';

type OptionType = {
    name: string,
    value: number,
}

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['../auth-common-styles.scss'],
})
export class SignUpComponent {
    registerRoles: OptionType[] = [
        {
            name: 'Student',
            value: RegisterRoles.Student,
        },
        {
            name: 'Teacher',
            value: RegisterRoles.Teacher,
        }
    ];

    firstNameError: string;
    lastNameError: string;
    emailError: string;
    mobilePhoneError: string;
    passwordError: string;
    passwordConfirmationError: string;
    roleError: string;
    groups: IFilterResponse<IGroup[]>;

    isStudent: boolean;

    registerForm = new FormGroup(
      {
        email: new FormControl('', {
          validators: [Validators.required, Validators.maxLength(50), Validators.pattern(emailFormatRegex)],
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
          validators: [Validators.required, Validators.pattern(mobilePhoneFormatRegex)],
          updateOn: 'submit',
        }),
        password: new FormControl('', {
          validators: [Validators.required, Validators.pattern(passFormatRegex)],
          updateOn: 'submit',
        }),
        passwordConfirmation: new FormControl('', {
          validators: [Validators.required],
          updateOn: 'submit',
        }),
        role: new FormControl('', {
          validators: [Validators.required],
          updateOn: 'change',
        }),
        group: new FormControl('', {
          updateOn: 'change',
        }),
      },
      {
        validators: matchpassword,
      },
    );

    user: ICreateUser = {
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        phone: '',
        role: null,
        group: null,
    };

    constructor(
        private authService: AuthService,
        private dialog: MatDialog,
        private router: Router,
        groupService: GroupsService,
    ) {
        groupService.getAllGroups({}).subscribe(res => {
          this.groups = res
        });
    }

    public RoleChanged() {
        this.isStudent = this.role.value == RegisterRoles.Student;
    }

    submitForm(event: SubmitEvent) {
        event.preventDefault();
        this.clearErrors();

        if (!this.validateForm()) {
            this.checkErrors();
            return;
        }
        this.signUp();
    }

    clearErrors() {
        this.firstNameError = '';
        this.lastNameError = '';
        this.emailError = '';
        this.passwordError = '';
        this.passwordConfirmationError = '';
        this.mobilePhoneError = '';
        this.roleError = '';
    }

    private checkErrors() {
      const firstName = this.firstName.value;
      const lastName = this.lastName.value;
      const email = this.email.value;
      const mobilePhone = this.mobilePhone.value;
      const password = this.password.value;
      const passwordConfirmation = this.passwordConfirmation.value;
      const nameRegex = /^([a-zA-Z-]){2,25}$/;
      const emailRegex =
        /^([a-zA-Z-]+([a-zA-Z0-9_.]+)?)@[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*\.[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*$/;
      const mobilePhoneRegex = /^[0-9]{10}$/;
      const passRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&0-9]).{6,25}$/;
      this.firstNameError =
        firstName !== null && nameRegex.test(firstName) ? '' : 'First name must be Latin from 2 to 25 characters';
      this.lastNameError =
        lastName !== null && nameRegex.test(lastName) ? '' : 'Last name must be Latin from 2 to 25 characters';
      this.emailError = emailRegex.test(email) ? '' : 'You entered not valid email';
      this.mobilePhoneError = mobilePhoneRegex.test(mobilePhone) ? '' : 'Mobile phone must consist of 10 digits';
      this.passwordError = passRegex.test(password)
        ? ''
        : 'The password must be between 6 and 25 characters long, contain uppercase and lowercase letters, and one of the characters @$!%*?&. or a number';
      this.passwordConfirmationError = password === passwordConfirmation ? '' : 'Password did not match';
      this.roleError = !this.role.valid ? 'Role is required' : '';
    }

    private validateForm() {
        return this.registerForm.valid;
    }

    private signUp() {
        this.user.firstName = this.firstName.value;
        this.user.lastName = this.lastName.value;
        this.user.email = this.email.value;
        this.user.phone = this.mobilePhone.value;
        this.user.password = this.password.value;
        this.user.role = this.role.value;
        this.user.group = this.group.value;

        this.authService.signUp(this.user).subscribe(
            (result) => {
                this.dialog.open(ModalComponent, {
                    data: {
                        header: 'Success',
                        content: (result as any).message,
                    },
                });
                const token = (result as any).value.accessToken;
                const user = (result as any).value;
                localStorage.setItem('accessToken', token);
                localStorage.setItem('user', JSON.stringify(user));
                this.router.navigate(['/']);
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

    get firstName(): FormControl {
        return this.registerForm.get('firstName') as FormControl;
    }

    get lastName(): FormControl {
        return this.registerForm.get('lastName') as FormControl;
    }

    get email(): FormControl {
        return this.registerForm.get('email') as FormControl;
    }

    get mobilePhone(): FormControl {
        return this.registerForm.get('mobilePhone') as FormControl;
    }

    get password(): FormControl {
        return this.registerForm.get('password') as FormControl;
    }

    get passwordConfirmation(): FormControl {
        return this.registerForm.get('passwordConfirmation') as FormControl;
    }

    get role(): FormControl {
        return this.registerForm.get('role') as FormControl;
    }

    get group(): FormControl {
        return this.registerForm.get('group') as FormControl;
    }
}
