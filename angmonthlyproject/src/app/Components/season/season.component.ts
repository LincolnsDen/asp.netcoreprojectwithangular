import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Season } from 'src/app/Models/season.model';
import { FetchData } from 'src/app/Service/fetch-data.service';

@Component({
  selector: 'app-season',
  templateUrl: './season.component.html',
  styleUrls: ['./season.component.css']
})
export class SeasonComponent{
  constructor(private mydata: FetchData) {
    this.getseasons();
    
  }
  private seasonList = [];
  public season: Season = new Season();
  getseasons() {
    return this.mydata.getseasons().subscribe((Response) => {
      (this.seasonList = Response), console.log(Response);
    });
  }
  get seasondata(): Season[] {
    return this.seasonList;
  }
  public delete(id: number) {
    return this.mydata.deleteseasons(id).subscribe((Response) => {
      this.getseasons();
    });
  }

  public editing: boolean = false;

  public submit(Form: NgForm) {
    if (this.editing) {
      return this.mydata.editseasons(this.season).subscribe((Response) => {
        this.getseasons();
        this.editing=false;
      });
    } else {
      return this.mydata.createseasons(this.season).subscribe((Response) => {
        this.getseasons();
      });
    }
  }
  public Update(Formd: any) {
    this.editing = true;
    Object.assign(this.season, Formd);
  }
}

