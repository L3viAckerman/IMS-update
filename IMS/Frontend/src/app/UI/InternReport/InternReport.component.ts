import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { ModalComponent } from '../../Shared/MaterialComponent/modal/modal.component';
import { InternReportService } from '../../Modules/InternReport/InternReport.Service';
import { InternReportEntity } from '../../Modules/InternReport/InternReport.Entity';
import { SearchInternReportEntity } from '../../Modules/InternReport/InternReport.SearchEntity';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';

@Component({
  selector: 'App-InternReport',
  templateUrl: './InternReport.component.html',
  styleUrls: ['./InternReport.component.css'],
  providers: [InternReportService, BottomToastsManager]
})
export class InternReportComponent extends CommonComponent<InternReportEntity> {
  Title: string = "Reports";
  SearchInternReportEntity: SearchInternReportEntity;
  constructor( InternReportService: InternReportService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(InternReportService, toastr, vcr);
    this.SearchInternReportEntity = new SearchInternReportEntity();
    this.Search(this.SearchInternReportEntity);
  }
}
