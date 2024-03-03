import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import { Observable } from 'rxjs';
import { IResponseT } from 'src/app/models/IResponse';
import { IStudentInformation } from 'src/app/models/IStudentInformation';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  controllerUrl: string;

  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/student';
  }

  getAllStudents() : Observable<IResponseT<IStudentInformation[]>> {
    return this.httpService.get(`${this.controllerUrl}?notVerified=false`);
  }

  getNotVerifiedStudents() : Observable<IResponseT<IStudentInformation[]>> {
    return this.httpService.get(`${this.controllerUrl}?notVerified=true`);
  }
}
