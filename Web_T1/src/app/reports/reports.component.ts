import { Component, OnInit } from '@angular/core';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  constructor(private service: APIService) { }
  data:any=[];
  ngOnInit(): void {
    this.getData();
  }
  getData(){
    this.service.getBaggage().subscribe(resp=>{
      this.callback(resp);
    }) 
  }
  callback(resp:any){
    this.data=resp;
    console.log(this.data);
  }

}
