import { Injectable } from '@angular/core';
import { AdminEntity } from "./Admin.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';

@Injectable()
export class AdminService extends HttpService<AdminEntity> {
  public AdminEntity: AdminEntity;
  constructor(private HttpClient: HttpClient) {
    super(HttpClient);
    this.url = "api/Admins";
  }
}
