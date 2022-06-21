import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {Fruit} from "../Models/fruit.model"
import {Season} from "../Models/season.model"

@Injectable({
    providedIn: 'root'
  })
export class FetchData {
constructor(private http: HttpClient)
{

}
getfruits(): Observable<any>
{
    return this.http.get('http://localhost:5000/fruit');
}

createfruits(fruit : any): Observable<any>
{
    return this.http.post('http://localhost:5000/fruit/create', fruit);
}

editfruits(fruit : any): Observable<any>
{
    return this.http.put('http://localhost:5000/fruit/edit', fruit);
}

deletefruits( id : number): Observable<any>
{
    return this.http.delete('http://localhost:5000/fruit/delete/'+id);
}



getseasons(): Observable<any>
{
    return this.http.get('http://localhost:5000/season');
}

createseasons(season : any): Observable<any>
{
    return this.http.post('http://localhost:5000/season/create', season);
}

editseasons(season : any): Observable<any>
{
    return this.http.put('http://localhost:5000/season/edit', season);
}

deleteseasons( id : number): Observable<any>
{
    return this.http.delete('http://localhost:5000/season/delete/'+id);
}



//For vegetable

getvegetables(): Observable<any>
{
    return this.http.get('http://localhost:5000/vegetable');
}

createvegetables(vegetable : any): Observable<any>
{
    return this.http.post('http://localhost:5000/vegetable/create', vegetable);
}

editvegetables(vegetable : any): Observable<any>
{
    return this.http.put('http://localhost:5000/vegetable/edit', vegetable);
}

deletevegetables( id : number): Observable<any>
{
    return this.http.delete('http://localhost:5000/vegetable/delete/'+id);
}






getsupplier(): Observable<any>
{
    return this.http.get('http://localhost:5000/suplier');
}

createsupplier(supplier : any): Observable<any>
{
    return this.http.post('http://localhost:5000/suplier/create', supplier);
}

editsupplier(supplier : any): Observable<any>
{
    return this.http.put('http://localhost:5000/suplier/edit', supplier);
}

deletesupplier( id : number): Observable<any>
{
    return this.http.delete('http://localhost:5000/suplier/delete/'+id);
}

}
