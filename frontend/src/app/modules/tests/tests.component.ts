import { Component } from "@angular/core";
import { AuthService } from "@core/services/auth.service";
import { Role } from "@shared/data/roles";
import {Router} from "@angular/router";

@Component({
    selector: 'app-student-profile-page',
    templateUrl: 'tests.component.html',
    styleUrls: ['tests.component.scss'],
})
export class TestsPageComponent {
    isTeacherOrAdmin: boolean;

    constructor(authService: AuthService, private router: Router) {
        this.isTeacherOrAdmin = authService.hasAnyRole([Role.admin, Role.teacher]);
    }

    public create() {
        this.router.navigateByUrl('tests/create');
    }

    public goToTest() {

    }
}
