import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from "./home.component";
import {Panel1Component} from "./panel1/panel1.component";

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'panel',
    component: Panel1Component
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
