import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { ModalComponent } from '../../Shared/MaterialComponent/modal/modal.component';
import { InternNewsService } from '../../Modules/InternNews/InternNews.Service';
import { InternNewsEntity } from '../../Modules/InternNews/InternNews.Entity';
import { SearchInternNewsEntity } from '../../Modules/InternNews/InternNews.SearchEntity';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { InternFollowService } from '../../Modules/InternFollow/InternFollow.Service';
import { InternFollowEntity } from '../../Modules/InternFollow/InternFollow.Entity';

@Component({
  selector: 'App-InternNews',
  templateUrl: './InternNews.Component.html',
  styleUrls: ['./InternNews.Component.css'],
  providers: [InternNewsService, BottomToastsManager, InternFollowService]
})
export class InternNewsComponent extends CommonComponent<InternNewsEntity> {
  SearchInternNewsEntity: SearchInternNewsEntity;
  constructor(public InternNewsService: InternNewsService, public InternFollowService: InternFollowService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(InternNewsService, toastr, vcr);
    this.SearchInternNewsEntity = new SearchInternNewsEntity();
    this.Search(this.SearchInternNewsEntity);
  }

  Follow(Internnew: InternNewsEntity) {
    this.InternNewsService.Follow(Internnew.Id).subscribe(If => {

    });
  }
}
