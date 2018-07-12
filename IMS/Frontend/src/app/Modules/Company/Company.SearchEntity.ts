import { FilterEntity } from "../Filter.Entity";

export class SearchCompanyEntity extends FilterEntity {
  Name: string;

  constructor(Company: any = null) {
    super(Company);
    this.Name = Company == null ? null : Company.Name;
  }
}
