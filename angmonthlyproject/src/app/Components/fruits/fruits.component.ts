import { Component, OnInit } from '@angular/core';
import { Fruit } from 'src/app/Models/fruit.model';
import { FetchData } from 'src/app/Service/fetch-data.service';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-fruits',
  templateUrl: './fruits.component.html',
  styleUrls: ['./fruits.component.css'],
})
export class FruitsComponent {

  constructor(private mydata: FetchData) {
    this.getfruits();
    console.log(this.fruitslist);
  }

  private fruitslist = [];
  public fruit: Fruit = new Fruit();

  getfruits() {
    return this.mydata.getfruits().subscribe((Response) => {
      (this.fruitslist = Response), console.log(Response);
    });
  }
  
  get fruitdata(): Fruit[] {
    return this.fruitslist;
  }
  public delete(id: number) {
    return this.mydata.deletefruits(id).subscribe((Response) => {
      this.getfruits();
    });
  }

  public editing: boolean = false;

  public submit(Form: NgForm) {
    if (this.editing) {
      return this.mydata.editfruits(this.fruit).subscribe((Response) => {
        this.getfruits();
        this.editing=false;
      });
    } else {
      return this.mydata.createfruits(this.fruit).subscribe((Response) => {
        this.getfruits();
      });
    }
  }
  public Update(Formd: any) {
    this.editing = true;
    Object.assign(this.fruit, Formd);
  }


  onFileChange(event: any) {
         
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
         this.fruit.image = e.target.result;
      };
      reader.readAsDataURL(event.target.files[0]);
    }}


}
