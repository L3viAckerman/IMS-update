import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { StudentService } from '../../Modules/Student/Student.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { StudentEntity } from '../../Modules/Student/Student.Entity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../Modules/User/User.Service';

@Component({
  selector: 'App-User',
  templateUrl: './StudentProfile.component.html',
  styleUrls: ['./StudentProfile.component.css'],
  providers: [StudentService, BottomToastsManager]
})
export class StudentProfileComponent extends CommonComponent<StudentEntity> {
  public StudentEntity: StudentEntity = new StudentEntity();
  constructor(public StudentService: StudentService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(StudentService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (Object.keys(params).length === 0) {
        StudentService.GetId(UserService.Current().Id).subscribe(p => {
          this.StudentEntity = p;
        });
      } else {
        if (params.StudentId != '00000000-0000-0000-0000-000000000000' )
        StudentService.GetId(params.StudentId).subscribe(p => {
          this.StudentEntity = p;
        });
      }
    });
  }

  Save(StudentEntity: StudentEntity) {
    debugger;
    if (this.StudentEntity.Id == null || this.StudentEntity.Id == '00000000-0000-0000-0000-000000000000') {
      this.StudentService.Create(StudentEntity).subscribe(p => {
        this.StudentEntity = p;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    }
    else {
      this.StudentService.Update(StudentEntity).subscribe(p => {
        this.StudentEntity = p;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    }
  }
}
