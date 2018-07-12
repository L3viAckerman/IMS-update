import { Injectable } from '@angular/core';
import { OperationEntity } from "./Operation.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class OperationService extends HttpService<OperationEntity>
{
    constructor(private Http:HttpClient)
    {
      super(Http);
      this.url = "api/Operations";
    }
}
