import { Injectable } from '@angular/core';
import { InternFollowEntity } from "./InternFollow.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class InternFollowService extends HttpService<InternFollowEntity>
{
  InternFollowEntity: InternFollowEntity;
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/InternFollows";
  }

  

}
