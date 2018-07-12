import {Entity } from "../Entity";
import { CompanyEntity } from "../Company/Company.Entity";
import { StudentEntity } from "../Student/Student.Entity";
import { InternReportEntity } from "../InternReport/InternReport.Entity";

export class InternshipCourseEntity extends Entity {
  Id: string = null;
  StudentId: string = null;
  CompanyId: string = null;
  Start: Date = null;
  End: Date = null;
  File: string = null;
  LecturerComment: string = null;
  CompanyComment: string = null;
  CompanyEntity: CompanyEntity = null;
  StudentEntity: StudentEntity = null;
    InternReportEntities : Array<InternReportEntity>;
    constructor (InternshipCourseEntity : any){
        super();
        this.IsEdit = false;
        this.IsActive = false;
        this.IsSelected = false;
    }
}
