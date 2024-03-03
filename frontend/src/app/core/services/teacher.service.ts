import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import { Observable } from 'rxjs';
import { IResponseT } from 'src/app/models/IResponse';
import { ITeacherInformation } from 'src/app/models/ITeacherInformation';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  controllerUrl: string;

  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/teacher';
  }

  getAllTeachers() : Observable<IResponseT<ITeacherInformation[]>> {
    return this.httpService.get(`${this.controllerUrl}?notVerified=false`);
  }

  getNotVerifiedTeachers() : Observable<IResponseT<ITeacherInformation[]>> {
    return this.httpService.get(`${this.controllerUrl}?notVerified=true`);
  }

  getTeacherById(id: number) : Observable<IResponseT<ITeacherInformation>> {
    return this.httpService.get(`${this.controllerUrl}/${id}`);
  }
}
