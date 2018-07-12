import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { HremployeeService } from '../../Modules/Hremployee/Hremployee.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { HremployeeEntity } from '../../Modules/Hremployee/Hremployee.Entity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';
import { CompanyService } from '../../Modules/Company/Company.Service';
import { CompanyEntity } from '../../Modules/Company/Company.Entity';

@Component({
  selector: 'App-User',
  templateUrl: './HremployeeProfile.component.html',
  styleUrls: ['./HremployeeProfile.component.css'],
  providers: [HremployeeService, CompanyService, BottomToastsManager]
})
export class HremployeeProfileComponent extends CommonComponent<HremployeeEntity> {
  public HremployeeEntity: HremployeeEntity = new HremployeeEntity();
  public CompanyEntity: CompanyEntity = new CompanyEntity();
  constructor(public HremployeeService: HremployeeService, CompanyService: CompanyService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(HremployeeService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (Object.keys(params).length === 0) {
        HremployeeService.GetId(UserService.Current().Id).subscribe(p => {
          this.HremployeeEntity = p;
        });
      } else {
        HremployeeService.GetId(params.HremployeeId).subscribe(p => {
          this.HremployeeEntity = p;
        });
      }
    });
    CompanyService.GetId(this.HremployeeEntity.CompanyId).subscribe(p => {
      this.CompanyEntity = p;
    });
  }

  Save() {
    this.HremployeeService.Update(this.HremployeeEntity).subscribe(p => {
      this.HremployeeEntity = p;
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.ShowError(e);
    });
  }
}
