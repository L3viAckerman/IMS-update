import { Entity } from "../Entity";

export class AdminEntity extends Entity {
  Id: string = null;
  Fullname: string = null;
  Vnumail: string = null;
  Gmail: string = null;
  Phone: string = null;
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
