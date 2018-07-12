import { Injectable } from '@angular/core';
import { InternReportEntity } from "./InternReport.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class InternReportService extends HttpService<InternReportEntity>{
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/Reports";
  }
}
