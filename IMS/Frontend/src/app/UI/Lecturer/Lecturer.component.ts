import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { LecturerService } from '../../Modules/Lecturer/Lecturer.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { LecturerEntity } from '../../Modules/Lecturer/Lecturer.Entity';
import { SearchLecturerEntity } from '../../Modules/Lecturer/Lecturer.SearchEntity';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'App-Lecturer',
  templateUrl: './Lecturer.Component.html',
  styleUrls: ['./Lecturer.Component.css'],
  providers: [LecturerService, BottomToastsManager]
})
export class LecturerComponent extends CommonComponent<LecturerEntity> {
  SearchLecturerEntity: SearchLecturerEntity;
  constructor(LecturerService: LecturerService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(LecturerService, toastr, vcr);
    this.SearchLecturerEntity = new SearchLecturerEntity();
    this.Search(this.SearchLecturerEntity);
  }
}
