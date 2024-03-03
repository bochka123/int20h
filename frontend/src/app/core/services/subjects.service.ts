import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import {IGroup} from "../../models/IGroup";
import {ISubject} from "../../models/ISubject";

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {
  controllerUrl: string;
  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/subject';
  }

  createSubject(subject: ISubject){
    return this.httpService.post(`${this.controllerUrl}`, subject);
  }
}
