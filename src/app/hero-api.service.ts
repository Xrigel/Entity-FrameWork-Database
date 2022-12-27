import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, tap} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HeroApiService {
readonly inspectionAPIUrl="https://localhost:7042/api";
  constructor(private http:HttpClient) { }
  GetHeroList():Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl+ "/Hero")
}
AddHero(data:any){
    return this.http.post(this.inspectionAPIUrl+"/Hero",data);
}
UpdateHero(id:number|string,data:any){
    return this.http.put(this.inspectionAPIUrl+ `/Hero/${id}`,data);
}
Deletehero(id:number|string){
    return this.http.delete(this.inspectionAPIUrl+`/Hero/${id}`);
}
}
