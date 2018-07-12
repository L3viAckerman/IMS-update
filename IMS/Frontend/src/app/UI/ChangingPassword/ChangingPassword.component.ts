import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { UserService } from '../../Modules/User/User.Service';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { UserEntity } from '../../Modules/User/User.Entity';
import { ActivatedRoute } from '@angular/router';
import { AbstractControl, FormGroup } from '@angular/forms/src/model';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { PasswordMatchValidators } from '../ChangingPassword/Password.Validators'
import { ModalComponent } from '../../Shared/MaterialComponent/modal/modal.component';


@Component({
  selector: 'App-ChangingPassword',
  templateUrl: './ChangingPassword.Component.html',
  styleUrls: ['./ChangingPassword.Component.css'],
  providers: [UserService, BottomToastsManager]
})
export class ChangingPasswordComponent extends CommonComponent<UserEntity> {
  public UserEntity: UserEntity;
  ChangePasswordForm: FormGroup;
  IsSuccess?: boolean;
  EditModalComponent: ModalComponent;
  constructor(ChangePasswordForm: FormBuilder, toastr: BottomToastsManager, vcr: ViewContainerRef, public route: ActivatedRoute, public UserService: UserService, ) {
    super(UserService, toastr, vcr);
    this.route.params.subscribe((params) => {
      if (Object.keys(params).length === 0) {
        UserService.GetId(UserService.Current().Id).subscribe(p => {
          this.UserEntity = p;
        });
      } else {
        UserService.GetId(params.UserId).subscribe(p => {
          this.UserEntity = p;
        });
      }
    });
    this.ChangePasswordForm = ChangePasswordForm.group({
      'old_password': [null, Validators.required],
      'new_password': [null, Validators.required],
      'confirm_password': [null, Validators.required]
    }, {
      validator: PasswordMatchValidators.passwordMatch('new_password', 'confirm_password')
      });
    this.EditModalComponent = new ModalComponent();
  }
  ChangePassword(value) {
    if (this.ChangePasswordForm.valid) {
      this.UserEntity.Password = this.ChangePasswordForm.controls['new_password'].value;
      let oldPassword = this.ChangePasswordForm.controls['old_password'].value;
      this.UserService.changePassword(oldPassword, this.UserEntity).subscribe(p => {
        this.toastr.ShowSuccess();
        this.IsSuccess = p;
        document.getElementById(this.EditModalComponent.ID).click();
      }, e => {
        this.toastr.ShowError(e);
      });
    }
    return null;
  }
  CloseModal() {
    this.IsSuccess = null;
  }
}
