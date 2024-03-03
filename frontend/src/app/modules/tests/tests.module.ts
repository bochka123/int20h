import { NgModule } from "@angular/core";
import { TestsPageComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";
import { TestFromComponent } from './test-from/test-from.component';
import {CommonModule, NgForOf} from "@angular/common";



@NgModule({
    declarations: [TestsPageComponent, TestFromComponent],
  imports: [TestsRoutingModule, NgForOf, CommonModule],
})

export class TestsModule {}
