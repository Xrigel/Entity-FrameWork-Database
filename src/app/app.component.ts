import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs"
import {HeroApiService} from "./hero-api.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  HeroList$!:Observable<any[]>;


  constructor(private service:HeroApiService) {
  }
  ngOnInit(): void {
    this.HeroList$=this.service.GetHeroList()
 }
 modalAdd(){
    alert("It is Working for nowo");
 }


}
