import { Component, OnInit } from '@angular/core';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {

  constructor(private service: APIService) { }
  data: any = [];
  ngOnInit(): void {
    this.getData();
  }
  getData() {
    this.service.getFlights().subscribe(resp => {
      this.callback(resp);
    })
  }
  callback(resp: any) {
    this.data = resp;
    console.log(this.data[2]);
  }

}
