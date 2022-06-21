import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Vegetable } from 'src/app/Models/vegetable.model';
import { FetchData } from 'src/app/Service/fetch-data.service';

@Component({
  selector: 'app-vegetable',
  templateUrl: './vegetable.component.html',
  styleUrls: ['./vegetable.component.css'],
})
export class VegetableComponent {
  constructor(private mydata: FetchData) {
    this.getvegetables();
  }
  private vegetableList = [];
  public vegetable: Vegetable = new Vegetable();

  getvegetables() {
    return this.mydata.getvegetables().subscribe((Response) => {
      (this.vegetableList = Response), console.log(Response);
    });
  }

  get vegetabledata(): Vegetable[] {
    return this.vegetableList;
  }

  public delete(id: number) {
    return this.mydata.deletevegetables(id).subscribe((Response) => {
      this.getvegetables();
    });
  }

  public editing: boolean = false;

  public submit(Form: NgForm) {
    if (this.editing) {
      return this.mydata
        .editvegetables(this.vegetable)
        .subscribe((Response) => {
          this.getvegetables();
          this.editing = false;
        });
    } else {
      return this.mydata
        .createvegetables(this.vegetable)
        .subscribe((Response) => {
          this.getvegetables();
        });
    }
  }
  public Update(Formd: any) {
    this.editing = true;
    Object.assign(this.vegetable, Formd);
  }

  onFileChange(event: any) {
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.vegetable.image = e.target.result;
      };
      reader.readAsDataURL(event.target.files[0]);
    }
  }
}
