import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from './app.component';
import { UserComponent } from "./UI/User/user.component";
import { InternReportComponent } from "./UI/InternReport/InternReport.component";
import { StudentComponent } from "./UI/Student/Student.component";
import { InternNewsComponent } from "./UI/InternNews/InternNews.component";
import { CompanyComponent } from "./UI/Company/company.component";
import { StudentProfileComponent } from "./UI/StudentProfile/StudentProfile.component";
import { InternshipResultComponent } from "./UI/StudentProfile/InternshipResult/InternshipResult.component";
import { LecturerProfileComponent } from "./UI/LecturerProfile/LecturerProfile.component";
import { StudyProgressComponent } from "./UI/StudyProgress/StudyProgress.component";
import { ChangingPasswordComponent } from "./UI/ChangingPassword/ChangingPassword.component";
import { LecturerComponent } from "./UI/Lecturer/Lecturer.component";
import { StudentListOfCompanyComponent } from "./UI/StudentListOfCompany/StudentListOfCompany.component";
import { NewStudentOfCompanyComponent } from "./UI/NewStudentOfCompany/NewStudentOfCompany.component";
import { InternNewsManagementComponent } from "./UI/InternNewsManagement/InternNewsManagement.component";
import { HremployeeProfileComponent } from "./UI/HremployeeProfile/HremployeeProfile.component";
import { EmailsComponent } from "./UI/Emails/Emails.component";
import { EmailNotSeenComponent } from "./UI/EmailNotSeen/EmailNotSeen.component";
import { EmailStarComponent } from './UI/EmailStar/EmailStar.component';
import { CompanyFormComponent } from './UI/CompanyForm/CompanyForm.component';
import { ListOfStudentLecturerComponent } from './UI/ListOfStudentLecturer/ListOfStudentLecturer.component';
import { FinalReportComponent } from './UI/FinalReport/FinalReport.component';
import { PeriodReportsComponent } from './UI/PeriodReports/PeriodReports.component';
import { PeriodReportComponent } from './UI/PeriodReport/PeriodReport.component';
import { NewInternNewsComponent } from './UI/NewInternNews/NewInternNews.component';
import { PeriodReportCommentComponent } from './UI/PeriodReportComment/PeriodReportComment.component';
import { FinalReportCommentComponent } from './UI/FinalReportComment/FinalReportComment.component';
import { DetailNewsComponent } from './UI/DetailNews/DetailNews.component';
import { OperationComponent } from "./UI/Operation/Operation.component";

const routes: Routes = [

  { path: '', component: AppComponent },
  { path: 'Users', component: UserComponent },
  { path: 'Reports', component: InternReportComponent },
  { path: 'Students', component: StudentComponent },
  { path: 'StudentProfile/:StudentId', component: StudentProfileComponent },
  { path: 'StudentProfile', component: StudentProfileComponent },
  { path: 'InternNews', component: InternNewsComponent },
  { path: 'Companies', component: CompanyComponent },
  { path: 'InternshipResult/:StudentId', component: InternshipResultComponent },
  { path: 'InternshipResult', component: InternshipResultComponent },
  { path: 'StudyProgress/:StudentId', component: StudyProgressComponent },
  { path: 'StudyProgress', component: StudyProgressComponent },
  { path: 'Lecturers', component: LecturerComponent },
  { path: 'LecturerProfile', component: LecturerProfileComponent },
  { path: 'LecturerProfile/:LecturerId', component: LecturerProfileComponent },
  { path: 'ChangePassword', component: ChangingPasswordComponent },
  { path: 'ChangePassword/:UserId', component: ChangingPasswordComponent },
  { path: 'StudentListOfCompany', component: StudentListOfCompanyComponent },
  { path: 'NewStudentOfCompany', component: NewStudentOfCompanyComponent },
  { path: 'NewStudentOfCompany/:CompanyId', component: NewStudentOfCompanyComponent },
  { path: 'InternNewsManagement', component: InternNewsManagementComponent },
  { path: 'HremployeeProfile', component: HremployeeProfileComponent },
  { path: 'HremployeeProfile/:HremployeeId', component: HremployeeProfileComponent },
  { path: 'Emails', component: EmailsComponent },
  { path: 'Emails/:UserId', component: EmailsComponent },
  { path: 'EmailNotSeen', component: EmailNotSeenComponent },
  { path: 'EmailNotSeen/:UserId', component: EmailNotSeenComponent },
  { path: 'EmailStar', component: EmailStarComponent },
  { path: 'EmailStar/:UserId', component: EmailStarComponent },
  { path: 'CompanyForm', component: CompanyFormComponent },
  { path: 'ListOfStudentLecturer', component: ListOfStudentLecturerComponent },
  { path: 'ListOfStudentLecturer/:LecturerId', component: ListOfStudentLecturerComponent },
  { path: 'FinalReport', component: FinalReportComponent },
  { path: 'PeriodReports', component: PeriodReportsComponent },
  { path: 'PeriodReport', component: PeriodReportComponent },
  { path: 'NewInternNews', component: NewInternNewsComponent },
  { path: 'PeriodReportComment', component: PeriodReportCommentComponent },
  { path: 'FinalReportComment', component: FinalReportCommentComponent },
  { path: 'DetailNews/:InternNewsId', component: DetailNewsComponent },
  { path: 'Operations', component: OperationComponent },
  {
    path: '**',
    redirectTo: 'StudentProfile',
  }

];
export const Routing = RouterModule.forRoot(routes);
