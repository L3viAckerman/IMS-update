import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../../Shared/CustomToaster';
import { InternshipCourseService } from '../../../Modules/InternshipCourse/InternshipCourse.Service';
import { debug } from 'util';
import { CommonComponent } from '../../../app.component';
import { InternshipCourseEntity } from '../../../Modules/InternshipCourse/InternshipCourse.Entity';
import { SearchInternshipCourseEntity } from '../../../Modules/InternshipCourse/InternshipCourse.SearchEntity';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../../Modules/User/User.Service';
import { StudentEntity } from '../../../Modules/Student/Student.Entity';
import { StudentService } from '../../../Modules/Student/Student.Service';

@Component({
  selector: 'App-InternshipCourse',
  templateUrl: './InternshipResult.Component.html',
  styleUrls: ['./InternshipResult.Component.css'],
  providers: [InternshipCourseService, BottomToastsManager, StudentService]
})

export class InternshipResultComponent extends CommonComponent<StudentEntity> {
  public StudentEntity: StudentEntity = new StudentEntity();
  constructor(public StudentService: StudentService, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, UserService: UserService) {
    super(StudentService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (Object.keys(params).length === 0) {
        StudentService.GetId(UserService.Current().Id).subscribe(p => {
          this.StudentEntity = p;
        });
      } else {
        StudentService.GetId(params.StudentId).subscribe(p => {
          this.StudentEntity = p;
        });
      }
    });
  }
  Download() {
    this.toastr.ShowWarning("Chức năng này chưa được cài đặt!");
  }


}
