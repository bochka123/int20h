import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import {IGroup} from "../../models/IGroup";
import { IFilterResponse, IGetRequest } from 'src/app/models/IFilterResponse';
import { Observable } from 'rxjs';
import { IResponseT } from 'src/app/models/IResponse';
import {ICreateTest} from "../../models/ICreateTest";
import {ITestDto} from "../../models/ITestDto";

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  controllerUrl: string;
  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/test';
  }

  createTest(test: ICreateTest): Observable<ITestDto>{
    return this.httpService.post(`${this.controllerUrl}/post`, test);
  }
}
