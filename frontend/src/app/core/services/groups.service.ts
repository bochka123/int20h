import { Injectable } from '@angular/core';
import {HttpService} from "@core/services/http.service";
import {IGroup} from "../../models/IGroup";

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
}
