import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FruitSupplier } from 'src/app/Models/supplier.model';
import { FetchData } from 'src/app/Service/fetch-data.service';
@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent{
  constructor(private mydata: FetchData) {
    this.getsupplier();console.log(this.supplierdata);
    

}
private supplierList = [];
  public supplier: FruitSupplier = new FruitSupplier();
  
  getsupplier() {
    return this.mydata.getsupplier().subscribe((Response) => {
      (this.supplierList = Response), console.log(Response);
    });
  }
  get supplierdata(): FruitSupplier[] {
    return this.supplierList;
  }

  public delete(id: number) {
    return this.mydata.deletesupplier(id).subscribe((Response) => {
      this.getsupplier();
    });
  }

  public editing: boolean = false;

  public submit(Form: NgForm) {
    if (this.editing) {
      return this.mydata.editsupplier(this.supplier).subscribe((Response) => {
        this.getsupplier();
        this.editing=false;
      });
    } else {
      return this.mydata.createsupplier(this.supplier).subscribe((Response) => {
        this.getsupplier();
      });
    }
  }
  public Update(Formd: any) {
    this.editing = true;
    Object.assign(this.supplier, Formd);
  }
}
