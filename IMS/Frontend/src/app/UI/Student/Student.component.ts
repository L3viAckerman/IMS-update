import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { StudentService } from '../../Modules/Student/Student.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { StudentEntity } from '../../Modules/Student/Student.Entity';
import { SearchStudentEntity } from '../../Modules/Student/Student.SearchEntity';

@Component({
  selector: 'App-Student',
  templateUrl: './Student.Component.html',
  styleUrls: ['./Student.Component.css'],
  providers: [StudentService, BottomToastsManager]
})
export class StudentComponent extends CommonComponent<StudentEntity> {
  SearchStudentEntity: SearchStudentEntity;
  constructor(StudentService: StudentService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(StudentService, toastr, vcr);
    this.SearchStudentEntity = new SearchStudentEntity();
    this.Search(this.SearchStudentEntity);
  }
}
