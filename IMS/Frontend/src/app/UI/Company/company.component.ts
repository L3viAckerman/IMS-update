import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { ModalComponent } from '../../Shared/MaterialComponent/modal/modal.component';
import { CompanyService } from '../../Modules/Company/Company.Service';
import { CompanyEntity } from '../../Modules/Company/Company.Entity';
import { SearchCompanyEntity } from '../../Modules/Company/Company.SearchEntity';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';

@Component({
  selector: 'App-Company',
  templateUrl: './Company.Component.html',
  styleUrls: ['./Company.Component.css'],
  providers: [CompanyService, BottomToastsManager]
})

export class CompanyComponent extends CommonComponent<CompanyEntity> {
  SearchCompanyEntity: SearchCompanyEntity;
  constructor(CompanyService: CompanyService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(CompanyService, toastr, vcr);
    this.SearchCompanyEntity = new SearchCompanyEntity();
    this.Search(this.SearchCompanyEntity);
  }
}
