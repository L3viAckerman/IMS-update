import { FilterEntity } from "../Filter.Entity";

export class SearchUserEntity extends FilterEntity {
  Username: string;

  constructor(User: any = null) {
    super(User);
    this.Username = User == null ? null : User.Username;
  }

}
