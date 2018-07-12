import { Injectable } from '@angular/core';
import { InternshipCourseEntity } from "./InternshipCourse.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class InternshipCourseService extends HttpService<InternshipCourseEntity>
{
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/Courses";
  }
}
