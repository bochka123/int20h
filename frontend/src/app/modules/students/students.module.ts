import { NgModule } from "@angular/core";
import { StudentsPageComponent } from "./students.component";
import { StudentsRoutingModule } from "./students-routing.module";

@NgModule({
    declarations: [StudentsPageComponent],
    imports: [StudentsRoutingModule],
})
export class StudentsModule {

}
