import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-baggage',
  templateUrl: './baggage.component.html',
  styleUrls: ['./baggage.component.css']
})
export class BaggageComponent implements OnInit {
  user:any;
  color:any;
  weight:any;
  cost:any;
  id:any;
  constructor() { }

  ngOnInit(): void {
  }
  alert(message:any, type:any) {
    const alertPlaceholder = document.getElementById('alertDiv') !  
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + 
    '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }
  getData(){
    this.user= (document.getElementById("user")! as HTMLInputElement).value;
    this.color= (document.getElementById("color")! as HTMLInputElement).value;
    this.weight= (document.getElementById("weight")! as HTMLInputElement).value;
    this.cost= (document.getElementById("cost")! as HTMLInputElement).value;
    this.id= (document.getElementById("id")! as HTMLInputElement).value;
    
    if(this.user==""||this.color==""||this.weight==""||this.cost==""||this.id==""){
      this.alert('Fill in all the data please','danger');
    }else{
      this.createJSON();
    }
  }
  createJSON(){
    let output: JSON;
    let obj: any=
    {
      "user":this.user,
      "color": this.color,
      "weight": this.weight,
      "cost": this.cost,
      "id":this.id
    };
    output=<JSON>obj
    console.log(output);
  }

}
