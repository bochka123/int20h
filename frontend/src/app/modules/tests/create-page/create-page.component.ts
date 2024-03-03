import {Component, OnInit} from '@angular/core';
import {ICreateTest} from "../../../models/ICreateTest";
import {TestsService} from "@core/services/test.service";
import {ITestDto} from "../../../models/ITestDto";
import {Router} from "@angular/router";
import {SubjectsService} from "@core/services/subjects.service";
import {ISubject} from "../../../models/ISubject";

@Component({
  selector: 'app-create-page',
  templateUrl: './create-page.component.html',
  styleUrls: ['./create-page.component.scss']
})
export class CreatePageComponent implements OnInit{
  test: ICreateTest = { title: '', description: '', cost: 0, subjectId: '' };
  subjects: ISubject[] = [];
  constructor( private subjectService: SubjectsService,
               private testService: TestsService,
               private router: Router) {
  }

  ngOnInit(): void {
    this.subjectService.getAllSubjects({}).subscribe((res) => {
      this.subjects = res.value as ISubject[];
    });
  }

  createTest(): void {
    this.testService.createTest(this.test).subscribe((res: any)=>{
      this.router.navigateByUrl(`tests/test/${res.value.id}`)
    })
  }
}
