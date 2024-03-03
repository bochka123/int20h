import { NgModule } from "@angular/core";
import { TestsPageComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [TestsPageComponent],
    imports: [TestsRoutingModule, CommonModule],
})

export class TestsModule {}
