import { Entity } from "../Entity";

export class UserEntity extends Entity {
  Id: string = null;
  Username: string = null;
  Roles: string[] = null;
  Password: string = null;
  AdminEntity: AdminEntity = null;
  constructor(User: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}

export class AdminEntity extends Entity {
  Id: string = null;
  Fullname: string = null;
  Organization: number = null;

  constructor(User: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}


