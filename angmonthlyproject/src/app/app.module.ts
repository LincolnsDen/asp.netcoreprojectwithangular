import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FruitsComponent } from './Components/fruits/fruits.component';
import { SeasonComponent } from './Components/season/season.component';
import {HttpClientModule} from '@angular/common/http'
import { FetchData } from './Service/fetch-data.service';
import { FormsModule } from '@angular/forms';
import { VegetableComponent } from './Components/vegetable/vegetable.component';
import { SupplierComponent } from './Components/supplier/supplier.component';

@NgModule({
  declarations: [
    AppComponent,
    FruitsComponent,
    SeasonComponent,
    VegetableComponent,
    SupplierComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    

  ],
  providers: [FetchData],
  bootstrap: [AppComponent]
})
export class AppModule { }
