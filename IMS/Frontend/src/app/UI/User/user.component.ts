import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { UserService } from '../../Modules/User/User.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { UserEntity } from '../../Modules/User/User.Entity';
import { SearchUserEntity } from '../../Modules/User/User.SearchEntity';

@Component({
  selector: 'App-User',
  templateUrl: './User.Component.html',
  styleUrls: ['./User.Component.css'],
  providers: [UserService, BottomToastsManager]
})
export class UserComponent extends CommonComponent<UserEntity> {
  SearchUserEntity: SearchUserEntity;
  constructor(UserService: UserService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(UserService, toastr, vcr);
    this.SearchUserEntity = new SearchUserEntity();
    this.Search(this.SearchUserEntity);
  }
}
