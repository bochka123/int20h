import { NgModule } from "@angular/core";
import { StudentsPageComponent } from "./students-page/students.component";
import { StudentsRoutingModule } from "./students-routing.module";
import {CommonModule} from "@angular/common";
import {StudentProfilePageComponent} from "@modules/students/student-profile-page/student-profile-page.component";

@NgModule({
    declarations: [StudentsPageComponent, StudentProfilePageComponent],
    imports: [StudentsRoutingModule, CommonModule],
})
export class StudentsModule {

}
