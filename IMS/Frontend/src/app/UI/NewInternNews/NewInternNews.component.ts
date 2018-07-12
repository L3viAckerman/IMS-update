import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { InternNewsService } from '../../Modules/InternNews/InternNews.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { InternNewsEntity } from '../../Modules/InternNews/InternNews.Entity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';
import { HttpService } from '../../Modules/HttpService';
import { HremployeeService } from '../../Modules/Hremployee/Hremployee.Service';
import { HremployeeEntity } from '../../Modules/Hremployee/Hremployee.Entity';

@Component({
  selector: 'App-User',
  templateUrl: './NewInternNews.component.html',
  styleUrls: ['./NewInternNews.component.css'],
  providers: [InternNewsService, HremployeeService, BottomToastsManager]
})
export class NewInternNewsComponent extends CommonComponent<InternNewsEntity> {
  public InternNewsEntity: InternNewsEntity = new InternNewsEntity();
  public HremployeeEntity: HremployeeEntity = new HremployeeEntity();
  constructor(public InternNewsService: InternNewsService, HremployeeService: HremployeeService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(InternNewsService, toastr, vcr);
    HremployeeService.GetId(UserService.Current().Id).subscribe(p => {
      this.HremployeeEntity = p;
      this.InternNewsEntity.CompanyId = p.CompanyId;
      this.InternNewsEntity.Id = "aa087f20-55a0-4ff1-bd5c-0dfa2f36e434";
    });
  }

  Save(InternNewsEntity: InternNewsEntity) {
    this.InternNewsService.Create(this.InternNewsEntity).subscribe(p => {
    });
  }
  //Save() {
  //  this.InternNewsService.Update(this.InternNewsEntity).subscribe(p => {
  //    this.InternNewsEntity = p;
  //    this.toastr.ShowSuccess();
  //  }, e => {
  //    this.toastr.ShowError(e);
  //  });
  //}
}
