import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import { Observable } from 'rxjs';
import {ICreateTest} from "../../models/ICreateTest";
import {ITestDto} from "../../models/ITestDto";
import {IQuestionDto} from "../../models/IQuestionDto";

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  controllerUrl: string;
  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/question';
  }

  get(id: string): Observable<IQuestionDto[]>{
    return  this.httpService.get(`${this.controllerUrl}?id=${id}`)
  }
  post(id: string, question: IQuestionDto): Observable<IQuestionDto>{
    return this.httpService.post(`${this.controllerUrl}?id=${id}`, question);
  }
}
