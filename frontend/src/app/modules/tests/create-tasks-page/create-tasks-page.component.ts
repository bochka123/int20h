import { Component } from '@angular/core';
import {IQuestionDto} from "../../../models/IQuestionDto";

@Component({
  selector: 'app-create-tasks-page',
  templateUrl: './create-tasks-page.component.html',
  styleUrls: ['./create-tasks-page.component.scss']
})
export class CreateTasksPageComponent {
  questions: IQuestionDto[]

  addQuestion(): void {
    this.questions.push({
      title: '',
      text: '',
      cost: 0,
      questionOptions: []
    });
  }

  addOption(questionIndex: number): void {
    this.questions[questionIndex].questionOptions.push({
      text: '',
      isCorrect: false
    });
  }
}
