import {Component, OnInit} from '@angular/core';
import {IQuestionDto} from "../../../models/IQuestionDto";
import {TestsService} from "@core/services/question.service";
import {ActivatedRoute, Router} from "@angular/router";
import {forkJoin} from "rxjs";

@Component({
  selector: 'app-create-tasks-page',
  templateUrl: './create-tasks-page.component.html',
  styleUrls: ['./create-tasks-page.component.scss']
})
export class CreateTasksPageComponent implements OnInit {
  questions: IQuestionDto[] = [];
  testId: string;

  constructor(private testService: TestsService,
              private route: ActivatedRoute,
              private router: Router) {
  }

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

  createTest() {
    const requests = this.questions.map(question => this.testService.post(this.testId, question));
    forkJoin(requests).subscribe(
      (results) => {
        this.router.navigateByUrl("tests");
      },
      (error) => {
        console.error('Error occurred during requests:', error);
      }
    );
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.testId = params['id'];
    });
  }
}
