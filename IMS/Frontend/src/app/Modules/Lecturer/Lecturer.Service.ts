import { Injectable } from '@angular/core';
import { LecturerEntity } from "./Lecturer.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class LecturerService extends HttpService<LecturerEntity>
{
    constructor(private Http:HttpClient)
    {
      super(Http);
        this.url = "api/Lecturers";
    }
}
