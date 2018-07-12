import { Entity } from "../Entity";

export class HremployeeEntity extends Entity {
  Id: string = null;
  CompanyId: string = null;
  Display: string = null;
  Name: String = null;
  constructor(User: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}



