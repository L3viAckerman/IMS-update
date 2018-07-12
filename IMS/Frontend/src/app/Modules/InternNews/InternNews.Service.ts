import { Injectable } from '@angular/core';
import { InternNewsEntity } from "./InternNews.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';
import { InternFollowEntity } from '../InternFollow/InternFollow.Entity';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class InternNewsService extends HttpService<InternNewsEntity> {
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/InternNews";
  }

  Follow(InternNewId: string, isShowLoading?: boolean): Observable<InternFollowEntity> {
    return this.intercept(this.http.post<InternFollowEntity>(this.url + '/' + InternNewId, null, { observe: 'response', headers: this.GetHeaders() }), isShowLoading).map(r => r.body);
  }
}
