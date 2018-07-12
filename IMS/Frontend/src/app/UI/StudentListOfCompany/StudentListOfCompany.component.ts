import { Component, ViewContainerRef } from "@angular/core";
import { SearchStudentEntity } from "../../Modules/Student/Student.SearchEntity";
import { StudentService } from "../../Modules/Student/Student.Service";
import { BottomToastsManager } from "../../Shared/CustomToaster";
import { CommonComponent } from "../../app.component";
import { StudentEntity } from "../../Modules/Student/Student.Entity";
import { UserService } from "../../Modules/User/User.Service";
import { HremployeeEntity } from "../../Modules/Hremployee/Hremployee.Entity";
import { HremployeeService } from "../../Modules/Hremployee/Hremployee.Service";
import { ActivatedRoute } from "@angular/router";
import { CompanyService } from "../../Modules/Company/Company.Service";
import { CompanyEntity } from "../../Modules/Company/Company.Entity";

@Component({
  selector: 'app-StudentListOfCompany',
  templateUrl: './StudentListOfCompany.component.html',
  styleUrls: ['./StudentListOfCompany.component.css'],
  providers: [StudentService, HremployeeService, CompanyService, BottomToastsManager]
})
export class StudentListOfCompanyComponent extends CommonComponent<StudentEntity>{
  public HremployeeEntity: HremployeeEntity = new HremployeeEntity();
  public CompanyEntity: CompanyEntity = new CompanyEntity();
  SearchStudentEntity: SearchStudentEntity = new SearchStudentEntity();
  constructor(StudentService: StudentService, HremployeeService: HremployeeService, CompanyService: CompanyService, toastr: BottomToastsManager, vcr: ViewContainerRef, public UserService: UserService) {
    super(StudentService, toastr, vcr);
    HremployeeService.GetId(UserService.Current().Id).subscribe(p => {
      this.SearchStudentEntity.CompanyId = p.CompanyId;
      this.Search(this.SearchStudentEntity);
    });
    CompanyService.GetId(this.HremployeeEntity.CompanyId).subscribe(p => {
      this.CompanyEntity = p;
    });
  }
}
