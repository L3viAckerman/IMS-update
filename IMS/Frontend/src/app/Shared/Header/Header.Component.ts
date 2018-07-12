import { Component } from "@angular/core";
import { MenuModel } from "../../menu-model";
// import {AuthService} from "../../Modules/Auth/Auth.Service";
import { UserEntity } from "../../Modules/User/User.Entity";
import { UserService } from "../../Modules/User/User.Service";

// import {LayerAccessControlEntity} from "../../Modules/LayerAccessControl/LayerAccessControl.Entity";

@Component({
  selector: 'public-header',
  templateUrl: './Header.Component.html',
  styleUrls: ['./Header.Component.css']
})
export class HeaderComponent {
  MenuList: MenuModel[];
  UserEntity: UserEntity;

  constructor(private UserService: UserService) {
    this.UserEntity = UserService.Current();
    setTimeout(() => {

      let Routes = []
      for (let i = 0; i < this.UserService.Routes.length; i++)
        for (let j = 0; j < this.UserEntity.Roles.length; j++)
          if (this.UserService.Routes[i].Role.indexOf(this.UserEntity.Roles[j]) > -1) {
            Routes.push(this.UserService.Routes[i]);
          };
      this.MenuList = Array<MenuModel>();
      let Home = new MenuModel("Trang chủ", Routes, "InternNews"); this.MenuList.push(Home);

      let List = new MenuModel("Tài khoản", Routes, "List"); this.MenuList.push(List);
      let Student = new MenuModel("Sinh viên", Routes, "Students"); List.addSub(Student);
      let Lecturer = new MenuModel("Giảng viên", Routes, "Lecturers"); List.addSub(Lecturer);
      let Admin = new MenuModel("Quản trị viên", Routes, "Admins"); List.addSub(Admin);
      let Hremployee = new MenuModel("Nhân viên tuyển dụng", Routes, "Hremployees"); List.addSub(Hremployee);
      let AdminProfile = new MenuModel("Thông tin quản trị", Routes, "AdminProfile"); this.MenuList.push(AdminProfile);

      let HremployeeProfile = new MenuModel("Thông tin nhân viên", Routes, "HremployeeProfile"); this.MenuList.push(HremployeeProfile);
      let Post = new MenuModel("Bài đăng của công ty", Routes, "InternNewsManagement"); this.MenuList.push(Post);
      let StudentListOfCompany = new MenuModel("DSSV của Công ty", Routes, "StudentListOfCompany"); this.MenuList.push(StudentListOfCompany);

      let InternNews = new MenuModel("Tin thực tập", Routes, "InternNews"); this.MenuList.push(InternNews);
      let StudentProfile = new MenuModel("Thông tin sinh viên", Routes, "StudentProfile"); this.MenuList.push(StudentProfile);
      let PersonalInformation = new MenuModel("Thông tin cá nhân", Routes, "StudentProfile"); StudentProfile.addSub(PersonalInformation);
      let StudyProgress = new MenuModel("Quá trình học tập", Routes, "StudyProgress"); StudentProfile.addSub(StudyProgress);
      let InternshipResult = new MenuModel("Kết quả thực tập", Routes, "InternshipResult"); StudentProfile.addSub(InternshipResult);
      let LecturerProfile = new MenuModel("Thông tin giảng viên", Routes, "LecturerProfile"); this.MenuList.push(LecturerProfile);
      let StudentReport = new MenuModel("Báo cáo", Routes, "StudentReports"); this.MenuList.push(StudentReport);
      let PeriodReport = new MenuModel("Báo cáo định kì", Routes, "PeriodReports"); StudentReport.addSub(PeriodReport);
      let FinalReport = new MenuModel("Báo cáo toàn văn", Routes, "FinalReport"); StudentReport.addSub(FinalReport);
      let ListOfStudentLecturer = new MenuModel("DSSV của GV", Routes, "ListOfStudentLecturer"); this.MenuList.push(ListOfStudentLecturer);

    }, 1500);

    //let ReportManagement = new MenuModel("Quản lí báo cáo", "ReportManagement"); this.MenuList.push(ReportManagement);
    //let PeriodReportManagement = new MenuModel("Báo cáo định kì", "PeriodReportManagement"); ReportManagement.addSub(PeriodReportManagement);
    //let FinalReportManagement = new MenuModel("Báo cáo toàn văn", "FinalReportManagement"); ReportManagement.addSub(FinalReportManagement);
  }

}
