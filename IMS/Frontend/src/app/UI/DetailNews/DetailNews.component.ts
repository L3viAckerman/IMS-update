import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { InternNewsService } from '../../Modules/InternNews/InternNews.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { InternNewsEntity } from '../../Modules/InternNews/InternNews.Entity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';

@Component({
  selector: 'App-User',
  templateUrl: './DetailNews.component.html',
  styleUrls: ['./DetailNews.component.css'],
  providers: [InternNewsService, BottomToastsManager]
})
export class DetailNewsComponent extends CommonComponent<InternNewsEntity> {
  public InternNewsEntity: InternNewsEntity = new InternNewsEntity();
  constructor(public InternNewsService: InternNewsService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(InternNewsService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (params.InternNewsId !== undefined) {
        InternNewsService.GetId(params.InternNewsId).subscribe(p => {
          this.InternNewsEntity = p;
        });
      } else {
        InternNewsService.GetId(params.InternNewsId).subscribe(p => {
          this.InternNewsEntity = p;
        });
      }
    });
  }
}
