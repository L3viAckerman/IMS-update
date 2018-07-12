import { FilterEntity } from "../Filter.Entity";

export class SearchLecturerEntity extends FilterEntity
{
  Vnumail : string;
  Fullname: string;
  constructor(LecturerEntity: any = null) {
      super(LecturerEntity);
      this.Vnumail = LecturerEntity === null ? null : LecturerEntity.Vnumail;
      this.Fullname = LecturerEntity === null ? null : LecturerEntity.Fullname;
    }
}
