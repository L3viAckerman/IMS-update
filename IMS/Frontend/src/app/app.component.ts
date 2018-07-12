import { Component, ViewContainerRef } from '@angular/core';
import {InputDiscussionComponent} from './Shared/MaterialComponent/InputDiscussion/InputDiscussion.component';
import {DropdownComponent} from './Shared/MaterialComponent/dropdown/dropdown.component';
import { HttpService } from './Modules/HttpService';
import { FilterEntity } from './Modules/Filter.Entity';
import { PagingModel } from './Shared/MaterialComponent/paging/paging.model';
import { Entity } from './Modules/Entity';
import { BottomToastsManager } from './Shared/CustomToaster';
import { UserService } from './Modules/User/User.Service';
import { OperationService } from './Modules/Operation/Operation.Service';
import { SearchOperationEntity } from './Modules/Operation/Operation.SearchEntity';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  DropdownComponent : DropdownComponent = new DropdownComponent();
  DiscussionComponent: InputDiscussionComponent = new InputDiscussionComponent();
  constructor(public UserService: UserService, public OperationService: OperationService) {
    let SearchEntity: SearchOperationEntity = new SearchOperationEntity();
    SearchEntity.Type = "UI";
    SearchEntity.Skip = 0;
    SearchEntity.Take = 100000;

    OperationService.Get(SearchEntity).subscribe(p => Object.assign( this.UserService.Routes ,p));
  }

}

export class CommonComponent<T extends Entity> {
  PagingModel: PagingModel = new PagingModel(7, 30);
  Entities: T[];
  temp: T;
  constructor(public HttpService: HttpService<T>, public toastr: BottomToastsManager, public vcr: ViewContainerRef) {
    this.toastr.setRootViewContainerRef(vcr);
  }
  Search(FilterEntity?: FilterEntity, IsPaging?: boolean) {
    FilterEntity.Skip = IsPaging ? this.PagingModel.Take * this.PagingModel.Active : 0;
    FilterEntity.Take = this.PagingModel.Take;
    this.HttpService.Get(FilterEntity).subscribe(p => {
      this.Entities = p;
      for (let i = 0; i < this.Entities.length; i++) this.Entities[i].IsEdit = false;
    });
    this.Count(FilterEntity);
  }
  Count(FilterEntity?: FilterEntity) {
    this.HttpService.Count(FilterEntity).subscribe(data => {
      this.PagingModel.TotalPage = Math.ceil(data / this.PagingModel.Take);
    });
  }
  Edit(T: T) {
    this.temp = JSON.parse(JSON.stringify(T));
    T.IsEdit = true;
  }
  Add(T: T) {
    this.Entities.unshift(T);
  }
  Delete(T: T) {
    this.HttpService.Delete(T).subscribe(p => {
      let indexOf = this.Entities.indexOf(T);
      this.Entities.splice(indexOf, 1);
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.ShowError(e);
    });
  }
  Save(T: T) {
    if (T.Id === undefined || T.Id === null) {
      this.HttpService.Create(T).subscribe(p => {
        this.Entities[0] = p;
        this.Entities[0].IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    } else {
      this.HttpService.Update(T).subscribe(p => {
        for (let i = 0; i < this.Entities.length; i++) {
          if (this.Entities[i].Id == p.Id) {
            this.Entities[i] = p;
            this.Entities[i].IsEdit = false;
          }
        }
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    }
  }
  Cancel(T: T) {
    if (T.Id === undefined || T.Id === null) {
      this.Entities.splice(0, 1);
    } else {
      for (let i = 0; i < this.Entities.length; i++) {
        if (this.Entities[i].Id == this.temp.Id) {
          this.Entities[i] = this.temp;
          this.Entities[i].IsEdit = false;
        }
      }
    }
  }
}

var Guid = { Empty: '00000000-0000-0000-0000-000000000000' };
