import { Component, OnInit } from '@angular/core';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-tablas',
  templateUrl: './tablas.component.html',
  styleUrls: ['./tablas.component.css']
})
export class TablasComponent implements OnInit {

  constructor(private service: APIService) { }
  data:any=[];
  ngOnInit(): void {
    this.getData();
  }
  getData(){
    this.service.getBagCar().subscribe(resp=>{
      this.callback(resp);
    }) 
  }
  callback(resp:any){
    this.data=resp;
    console.log(this.data[2]);
  }

}
