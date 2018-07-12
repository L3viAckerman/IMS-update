import { Injectable } from '@angular/core';
import { StudentEntity } from "./Student.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class StudentService extends HttpService<StudentEntity> {
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/students";
  }
}

