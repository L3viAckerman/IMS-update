import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { StudentService } from '../../Modules/Student/Student.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { StudentEntity } from '../../Modules/Student/Student.Entity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';
import { HremployeeEntity } from '../../Modules/Hremployee/Hremployee.Entity';
import { HremployeeService } from '../../Modules/Hremployee/Hremployee.Service';
import { SearchInternNewsEntity } from '../../Modules/InternNews/InternNews.SearchEntity';
import { InternNewsService } from '../../Modules/InternNews/InternNews.Service';
import { InternNewsEntity } from '../../Modules/InternNews/InternNews.Entity';
import { CompanyService } from '../../Modules/Company/Company.Service';
import { CompanyEntity } from '../../Modules/Company/Company.Entity';

@Component({
  selector: 'App-User',
  templateUrl: './InternNewsManagement.component.html',
  styleUrls: ['./InternNewsManagement.component.css'],
  providers: [InternNewsService, HremployeeService, CompanyService, BottomToastsManager]
})
export class InternNewsManagementComponent extends CommonComponent<InternNewsEntity> {
  public HremployeeEntity: HremployeeEntity = new HremployeeEntity();
  public CompanyEntity: CompanyEntity = new CompanyEntity();
  SearchInternNewsEntity: SearchInternNewsEntity = new SearchInternNewsEntity();
  constructor(public InternNewsService: InternNewsService, HremployeeService: HremployeeService, CompanyService: CompanyService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(InternNewsService, toastr, vcr);
    HremployeeService.GetId(UserService.Current().Id).subscribe(p => {
      this.HremployeeEntity = p;
      this.SearchInternNewsEntity.CompanyId = p.CompanyId;
      this.Search(this.SearchInternNewsEntity);
    });
    CompanyService.GetId(this.HremployeeEntity.CompanyId).subscribe(p => {
      this.CompanyEntity = p;
    });
  }
}
