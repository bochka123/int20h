import { NgModule } from "@angular/core";
import { TestsPageComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";
import { TestFromComponent } from './test-from/test-from.component';
import {CommonModule, NgForOf} from "@angular/common";
import { CreatePageComponent } from './create-page/create-page.component';
import {FormsModule} from "@angular/forms";
import { CreateTasksPageComponent } from './create-tasks-page/create-tasks-page.component';



@NgModule({
  declarations: [TestsPageComponent, CreatePageComponent, CreateTasksPageComponent],
  imports: [TestsRoutingModule, FormsModule, NgForOf, CommonModule],
})

export class TestsModule {}
