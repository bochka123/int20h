import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import {ISubject} from "../../models/ISubject";
import { Observable } from 'rxjs';
import { IResponseT } from 'src/app/models/IResponse';
import { IFilterResponse, IGetRequest } from 'src/app/models/IFilterResponse';

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

  getAllSubjects(request: IGetRequest): Observable<IFilterResponse<ISubject[]>>{
    return this.httpService.post(`${this.controllerUrl}/GetAll`, request);
  }

  getUserSubjects(request: { userEmail: string }): Observable<IResponseT<ISubject[]>>{
    return this.httpService.post(`${this.controllerUrl}/GetUserSubjects`, request);
  }
}
