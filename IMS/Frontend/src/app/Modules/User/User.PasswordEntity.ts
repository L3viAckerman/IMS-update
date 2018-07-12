import { UserEntity} from "./User.Entity";

export class PasswordEntity {
  UserEntity: UserEntity;
  OldPassword: string;
  constructor(UserEntity: UserEntity, OldPassword: string) {
    this.UserEntity = UserEntity;
    this.OldPassword = OldPassword;
  }
}
