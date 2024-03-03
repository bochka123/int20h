import { Component } from "@angular/core";
import { AuthService } from "@core/services/auth.service";
import { Role } from "@shared/data/roles";
import {Router} from "@angular/router";
import { ITestDto } from "src/app/models/ITestDto";
import { TestsService } from "@core/services/test.service";

@Component({
    selector: 'app-student-profile-page',
    templateUrl: 'tests.component.html',
    styleUrls: ['tests.component.scss'],
})
export class TestsPageComponent {
    isTeacherOrAdmin: boolean;
    tests: ITestDto[];

    constructor(authService: AuthService, private router: Router, testService: TestsService) {
        this.isTeacherOrAdmin = authService.hasAnyRole([Role.admin, Role.teacher]);
        testService.getTest({}).subscribe(res => { if(res.value) this.tests = res.value });
    }

    public create() {
        this.router.navigateByUrl('tests/create');
    }

    public goToTest(id?: string) {
        this.router.navigateByUrl(`tests/pass-test/${id}`);
    }
}
