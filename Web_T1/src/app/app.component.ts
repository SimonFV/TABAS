import { Component } from '@angular/core';
import { APIService} from './services/api.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TABAS';
  constructor(private service:APIService){
    this.service.getItem().subscribe(resp=>{
      console.log(resp);
    })
  }
}
