import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import { Observable } from 'rxjs';
import { IResponseT } from 'src/app/models/IResponse';
import { IStudentInformation } from 'src/app/models/IStudentInformation';
import { IPinToSubject } from 'src/app/models/IStudentSubject';

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

  getStudentById(id: number) : Observable<IResponseT<IStudentInformation>> {
    return this.httpService.get(`${this.controllerUrl}/${id}`);
  }

  pinStudentToSubject(request: IPinToSubject): Observable<IResponseT<IStudentInformation>> {
    return this.httpService.put(`${this.controllerUrl}`, request);
  }
}
