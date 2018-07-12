import { Injectable } from '@angular/core';
import { LecturerFollowEntity } from "./LecturerFollow.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class LecturerFollowService extends HttpService<LecturerFollowEntity>
{
    constructor (private Http : HttpClient)
    {
      super(Http);
        this.url = "api/LecturerFollows";
    }
}
