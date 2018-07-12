import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { AdminService } from '../../Modules/Admin/Admin.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { AdminEntity } from '../../Modules/Admin/Admin.Entity';
import { SearchAdminEntity } from '../../Modules/Admin/Admin.SearchEntity';

@Component({
  selector: 'App-Admin',
  templateUrl: './Admin.Component.html',
  styleUrls: ['./Admin.Component.css'],
  providers: [AdminService, BottomToastsManager]
})
export class AdminComponent extends CommonComponent<AdminEntity> {
  SearchAdminEntity: SearchAdminEntity;
  constructor(AdminService: AdminService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(AdminService, toastr, vcr);
    this.SearchAdminEntity = new SearchAdminEntity();
    this.Search(this.SearchAdminEntity);
  }
}
