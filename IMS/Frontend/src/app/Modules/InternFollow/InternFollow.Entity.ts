import {Entity} from "../Entity";
import { InternNewsEntity } from "../InternNews/InternNews.Entity";
import { StudentEntity } from "../Student/Student.Entity";


export class InternFollowEntity extends Entity
{
  Id: string = null;
  StudentId: string = null;
  InternNewsId: string = null;
  Status: number = null; 
  InternNews: InternNewsEntity = null;
  Student: StudentEntity = null;
    constructor(InternFollow: any = null) {
        super();
        this.IsEdit = false;
        this.IsActive = false;
        this.IsSelected = false;
    }
}
