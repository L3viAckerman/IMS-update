import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';
import { LecturerService } from '../../Modules/Lecturer/Lecturer.Service';
import { LecturerEntity } from '../../Modules/Lecturer/Lecturer.Entity';

@Component({
  selector: 'App-LecturerProfile',
  templateUrl: './LecturerProfile.component.html',
  styleUrls: ['./LecturerProfile.component.css'],
  providers: [LecturerService, BottomToastsManager]
})
export class LecturerProfileComponent extends CommonComponent<LecturerEntity> {
  public LecturerEntity: LecturerEntity = new LecturerEntity();
  constructor(public LecturerService: LecturerService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(LecturerService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (Object.keys(params).length === 0) {
        LecturerService.GetId(UserService.Current().Id).subscribe(p => {
          this.LecturerEntity = p;
        });
      } else {
        LecturerService.GetId(params.LecturerId).subscribe(p => {
          this.LecturerEntity = p;
        });
      }
    });
  }

  Save() {
    this.LecturerService.Update(this.LecturerEntity).subscribe(p => {
      this.LecturerEntity = p;
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.ShowError(e);
    });
  }
}
