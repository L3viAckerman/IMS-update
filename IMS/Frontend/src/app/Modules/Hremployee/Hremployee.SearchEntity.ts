import { FilterEntity } from "../Filter.Entity";

export class SearchHremployeeEntity extends FilterEntity {
  Name: string;
  CompanyId: string;
  constructor(Hremployee: any = null) {
    super(Hremployee);
    this.Name = Hremployee == null ? null : Hremployee.Name;
    this.CompanyId = Hremployee == null ? null : Hremployee.CompanyId;
  }

}
