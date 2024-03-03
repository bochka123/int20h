import { Component } from '@angular/core';
import {IQuestionDto} from "../../../models/IQuestionDto";

@Component({
  selector: 'app-student-profile-page',
  templateUrl: './tests-page.component.html',
  styleUrls: ['./tests-page.component.scss']
})
export class TestsPageComponent {
  questions: IQuestionDto[]

}
