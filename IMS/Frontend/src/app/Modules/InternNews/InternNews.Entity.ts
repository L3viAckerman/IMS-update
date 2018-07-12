import { Entity } from "../Entity";
import { InternFollowEntity } from "../InternFollow/InternFollow.Entity";

export class InternNewsEntity extends Entity {
  Id: string = null;
  Title: string = null;
  Content: string = null;
  ExpiredDate: Date = null;
  CompanyId: string = null;
  InternFollowEntities: Array<InternFollowEntity> = null;

  constructor(InternNews: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}



