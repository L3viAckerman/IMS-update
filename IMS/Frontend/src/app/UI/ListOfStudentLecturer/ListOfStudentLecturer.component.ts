import { Component, ViewContainerRef } from "@angular/core";
import { SearchStudentEntity } from "../../Modules/Student/Student.SearchEntity";
import { StudentService } from "../../Modules/Student/Student.Service";
import { BottomToastsManager } from "../../Shared/CustomToaster";
import { CommonComponent } from "../../app.component";
import { StudentEntity } from "../../Modules/Student/Student.Entity";
import { UserService } from "../../Modules/User/User.Service";

@Component({
  selector: 'app-ListOfStudentLecturer',
  templateUrl: './ListOfStudentLecturer.component.html',
  styleUrls: ['./ListOfStudentLecturer.component.css'],
  providers: [StudentService, BottomToastsManager]
})
export class ListOfStudentLecturerComponent extends CommonComponent<StudentEntity>{
  SearchStudentEntity: SearchStudentEntity = new SearchStudentEntity();
  constructor(StudentService: StudentService, toastr: BottomToastsManager, vcr: ViewContainerRef, public UserService: UserService) {
    super(StudentService, toastr, vcr);
    this.SearchStudentEntity.LecturerId = UserService.Current().Id;
    this.Search(this.SearchStudentEntity);
  }
}
