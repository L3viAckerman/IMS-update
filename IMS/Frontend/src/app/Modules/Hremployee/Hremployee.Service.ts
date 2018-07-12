import { Injectable } from '@angular/core';
import { HremployeeEntity } from "./Hremployee.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class HremployeeService extends HttpService<HremployeeEntity> {
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/Hremployees";
  }
}

