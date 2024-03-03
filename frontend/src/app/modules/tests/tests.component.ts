import { Component } from "@angular/core";
import { AuthService } from "@core/services/auth.service";
import { Role } from "@shared/data/roles";

@Component({
    selector: 'app-student-profile-page',
    templateUrl: 'tests.component.html',
    styleUrls: ['tests.component.scss'],
})
export class TestsPageComponent {
    isTeacherOrAdmin: boolean;

    constructor(authService: AuthService) {
        this.isTeacherOrAdmin = authService.hasAnyRole([Role.admin, Role.teacher]);
        console.log(authService.hasAnyRole([Role.admin, Role.teacher]));
    }

    public create() {

    }
}
