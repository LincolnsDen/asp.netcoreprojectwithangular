import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FruitsComponent } from './Components/fruits/fruits.component';
import { SeasonComponent } from './Components/season/season.component';
import { SupplierComponent } from './Components/supplier/supplier.component';
import { VegetableComponent } from './Components/vegetable/vegetable.component';

const routes: Routes = [
  {path:"" , component: FruitsComponent},
  {path:"vegetable" , component: VegetableComponent},
  {path:"season" , component: SeasonComponent},
  {path:"supplier" , component: SupplierComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
