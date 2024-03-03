import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import {IGroup} from "../../models/IGroup";
import { IFilterResponse, IGetRequest } from 'src/app/models/IFilterResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroupsService {
  controllerUrl: string;
  constructor(private httpService: HttpService) {
    this.controllerUrl = 'api/group';
  }

  createGroup(group: IGroup){
    return this.httpService.post(`${this.controllerUrl}`, group);
  }

  getAllGroups(request: IGetRequest): Observable<IFilterResponse<IGroup[]>>{
    return this.httpService.post(`${this.controllerUrl}/GetAll`, request);
  }
}
