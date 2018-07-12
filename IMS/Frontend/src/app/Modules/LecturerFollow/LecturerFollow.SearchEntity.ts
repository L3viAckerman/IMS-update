import { FilterEntity } from "../Filter.Entity";

export class SearchLecturerFollowEntity extends FilterEntity
{
    Studentname : string;
    MSSV : string;
    Status? : number;
    constructor(LecturerFollowEntity : any)
    {
        super(LecturerFollowEntity);
        if(LecturerFollowEntity!=null){
            this.Studentname = LecturerFollowEntity.StudentName == null ? null : LecturerFollowEntity.StudentName;
            this.MSSV = LecturerFollowEntity.MSSV == null ? null :  LecturerFollowEntity.MSSV;
            this.Status = LecturerFollowEntity.Status == null  ? null : LecturerFollowEntity.Status;
        }
    }
}