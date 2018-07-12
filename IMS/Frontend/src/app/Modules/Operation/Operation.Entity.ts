import {Entity } from "../Entity";

export class OperationEntity extends Entity {
  Id: string = null;
  Name: string = null;
  Link: string = null;
  Method: string = null;
  Role: string = null;
  Roles: string[] = null;
  constructor(OperationEntity? : any){
        super();
        this.IsEdit = false;
        this.IsActive = false;
        this.IsSelected = false;
    }
}
