import { CommonModule, DatePipe, NgForOf, NgIf } from '@angular/common';
import {NgModule} from "@angular/core";
import {MainComponent} from "@modules/main/main.component";
import {MainContentComponent} from "@modules/main/main-content/main-content.component";
import {SharedModule} from "@shared/shared.module";
import {MainRoutingModule} from "@modules/main/main-routing.module";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
    declarations: [MainComponent, MainContentComponent],
    imports: [
        SharedModule,
        MainRoutingModule,
        NgForOf,
        DatePipe,
        NgIf,
        CommonModule,
        ReactiveFormsModule,
    ],
})
export class MainModule {}
