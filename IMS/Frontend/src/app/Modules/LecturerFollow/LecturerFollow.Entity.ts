import {Entity} from "../Entity";
import { StudentEntity } from "../Student/Student.Entity";
import { LecturerEntity } from "../Lecturer/Lecturer.Entity";

export class LecturerFollowEntity extends Entity{
  Id: string = null;
  StudentId: string = null;
  LecturerId: string = null;
  Status: number = null;
  Start: Date = null;
  End: Date = null;
  Lecturer: LecturerEntity = null;
  Student: StudentEntity = null;
    constructor(LecturerFollowEntity : any)
    {
        super();
        this.IsEdit = false;
        this.IsActive = false;
        this.IsSelected = false;
    }
}
