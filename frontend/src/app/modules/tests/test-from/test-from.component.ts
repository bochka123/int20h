import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestsService } from '@core/services/test.service';
import { TestsService as QuestionServicse } from '@core/services/question.service';
import { IQuestionDto } from 'src/app/models/IQuestionDto';
import { ITest } from 'src/app/models/ITest';
import { ITestDto } from 'src/app/models/ITestDto';

type Question = {
  text: string;
};

type CustomType = {
  title: string;
  text: string;
  questions: Question[];
};

@Component({
  selector: 'app-test-from',
  templateUrl: './test-from.component.html',
  styleUrls: ['./test-from.component.scss'],
})
export class TestFromComponent {
  value: string;
  test?: ITestDto;
  questions?: IQuestionDto[];

  constructor(testService: TestsService, route: ActivatedRoute, questionService: QuestionServicse) {
    testService.getTest({}).subscribe((res) => {
      route.params.subscribe((params) => {
        if (res.value) {
          this.test = res.value.find((t) => t.id == params['id']);

          questionService.get(this.test?.id || '').subscribe(q => this.questions = q);
        }
      });
    });
  }

  RetrieveAnswer() {}
  OnItemChange(e: Event) {
    this.value = (e.target as HTMLInputElement).getAttribute('name') || '';
  }
}
