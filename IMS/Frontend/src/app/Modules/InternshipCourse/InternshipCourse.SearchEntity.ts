import { FilterEntity } from "../Filter.Entity";

export class SearchInternshipCourseEntity extends FilterEntity
{
    StudentName : string;
    //CompanyName : string;
    constructor(InternshipCourseEntity?: any)
    {
        super(InternshipCourseEntity);
        this.StudentName = InternshipCourseEntity==null ? null : InternshipCourseEntity.Student.Name;
        //this.CompanyName = InternshipCourseEntity==null ? null : InternshipCourseEntity.Company.Name;
    }
}
