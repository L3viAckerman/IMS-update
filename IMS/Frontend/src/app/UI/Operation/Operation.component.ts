import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { OperationService } from '../../Modules/Operation/Operation.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { OperationEntity } from '../../Modules/Operation/Operation.Entity';
import { SearchOperationEntity } from '../../Modules/Operation/Operation.SearchEntity';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'App-Student',
  templateUrl: './Operation.Component.html',
  styleUrls: ['./Operation.Component.css'],
  providers: [OperationService, BottomToastsManager]
})
export class OperationComponent extends CommonComponent<OperationEntity> {
  SearchOperationEntity: SearchOperationEntity;
  Roles = ['USER', 'STUDENT', 'LECTURER', 'ADMIN', 'HrEmployee'];
  Methods = ['UI', 'GET', 'POST', 'PUT', 'DELETE'];
  constructor(OperationService: OperationService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(OperationService, toastr, vcr);
    this.SearchOperationEntity = new SearchOperationEntity();
    this.Search(this.SearchOperationEntity);
  }
}
