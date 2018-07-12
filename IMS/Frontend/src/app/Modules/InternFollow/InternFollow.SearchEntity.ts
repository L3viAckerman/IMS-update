import { FilterEntity } from "../Filter.Entity";
import { InternNewsEntity } from "../InternNews/InternNews.Entity";
import { StudentEntity } from "../Student/Student.Entity";

export class SearchInternFollowEntity extends FilterEntity
{
    Status : number; 
    InternNewsName :string;
    StudentName :string;
    MSSV : string;
    constructor(InternFollow :any){
        super(InternFollow);
        if(InternFollow!=null)
        {
            this.InternNewsName = InternFollow.InternNews == null ? null : InternFollow.InternNews.Title;
            this.StudentName = InternFollow.Student == null ? null : InternFollow.Student.Name;
            this.MSSV = InternFollow.Student == null ? null : InternFollow.Student.Code;
          this.Status = InternFollow.Status == null ? null : InternFollow.Status;
        }
    }
}
