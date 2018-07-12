import { Entity } from "../Entity";

export class InternReportEntity extends Entity {
  Id: string = null;
  InternshipCourseId: string = null;
  Content: string = null;
  PartnerScore: number = null;
  LecturerScore: number = null;
  CompanyId: string = null;
  LecturerComment: string = null;
  CompanyComment: string = null;
  constructor(User: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}



