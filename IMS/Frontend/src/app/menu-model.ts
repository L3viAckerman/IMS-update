import { isNullOrUndefined } from "util";
import { OperationEntity } from "./Modules/Operation/Operation.Entity";

export class MenuModel {
  Name: string;
  Link: string;
  Sub: MenuModel[];
  Routes: OperationEntity[];
  IsShow: boolean;
  constructor(Name: string, routes: OperationEntity[], Link?: string, Sub?: Array<MenuModel>) {
    this.Routes = routes;
    this.Name = Name;
    if (!isNullOrUndefined(Link)) {
      this.Link = Link;
    } else {
      this.Link = "";
    }
    this.IsShow = false;
    for (let i = 0; i < this.Routes.length; i++) {
      if (this.Routes[i].Link === this.Link)
        this.IsShow = true;
    }

    if (!isNullOrUndefined(Sub)) {
      this.Sub = Sub;
    } else {
      this.Sub = [];
    }
  }

  addSub(Sub: MenuModel): void {
    this.Sub.push(Sub);
  }

  hasSub(): boolean {
    return (!(isNullOrUndefined(this.Sub) || this.Sub.length == 0));
  }
}
