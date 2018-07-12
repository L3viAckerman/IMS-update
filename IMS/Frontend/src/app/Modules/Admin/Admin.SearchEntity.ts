import { FilterEntity } from "../Filter.Entity";

export class SearchAdminEntity extends FilterEntity {
  Fullname: string;

  constructor(Admin: any = null) {
    super(Admin);
    this.Fullname = Admin == null ? null : Admin.Fullname;
  }

}
