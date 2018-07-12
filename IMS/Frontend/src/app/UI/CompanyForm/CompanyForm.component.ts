import { Component, Input, Output, OnInit, EventEmitter, ViewContainerRef } from '@angular/core';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { ModalComponent } from '../../Shared/MaterialComponent/modal/modal.component';
import { CompanyService } from '../../Modules/Company/Company.Service';
import { CompanyEntity } from '../../Modules/Company/Company.Entity';
import { SearchCompanyEntity } from '../../Modules/Company/Company.SearchEntity';
import { debug } from 'util';
import { CommonComponent } from '../../app.component';
import { Options } from "selenium-webdriver";
import { InputfileComponent } from '../../Shared/MaterialComponent/inputfile/inputfile.component';

@Component({
  selector: 'App-CompanyForm',
  templateUrl: './CompanyForm.Component.html',
  styleUrls: ['./CompanyForm.Component.css'],
  providers: [CompanyService, BottomToastsManager]
})

export class CompanyFormComponent extends CommonComponent<CompanyEntity>{
    CompanyEntity: CompanyEntity;
    InputFile: InputfileComponent;
    
    constructor(public CompanyService: CompanyService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
        super(CompanyService, toastr, vcr);
        this.CompanyEntity = new CompanyEntity();
        this.InputFile = new InputfileComponent();
        
    }
    
    Clear()
    {
        this.CompanyEntity.Name = "";
        this.CompanyEntity.Address = "";
        
    }
    Add()
    {
        this.CompanyService.Create(new Company(this.CompanyEntity)).subscribe(p => {
            this.CompanyEntity = p;
            this.toastr.ShowSuccess();
          }, e => {
            this.toastr.ShowError(e);
        });
        
    }
}
export class Company
{
  Name: string;
  Address: string;
  constructor (CompanyEntity: CompanyEntity) {
    this.Name = CompanyEntity.Name;
    this.Address = CompanyEntity.Address;
  }
}
