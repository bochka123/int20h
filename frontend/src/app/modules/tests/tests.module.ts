import { NgModule } from "@angular/core";
import { TestsPageComponent } from "./tests.component";
import { TestsRoutingModule } from "./tests-routing.module";
import { CreatePageComponent } from './create-page/create-page.component';
import {FormsModule} from "@angular/forms";
import {NgForOf} from "@angular/common";



@NgModule({
    declarations: [TestsPageComponent, CreatePageComponent],
  imports: [TestsRoutingModule, FormsModule, NgForOf],
})

export class TestsModule {}
