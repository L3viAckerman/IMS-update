import { Entity } from "../Entity";

export class CompanyEntity extends Entity {
  Id: string = null;
  Name: string = null;
  Address: string = null;
  IsEdit: boolean = null;
  IsActive: boolean = null;
  IsSelected: boolean = null;

  constructor(Company: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}
