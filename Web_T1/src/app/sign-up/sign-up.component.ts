import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent implements OnInit {
    
  myRouterLink = ""
  name:any;
  lastName:any;
  scndLastName:any;
  ID:any;
  email:any;
  pass:any;
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router) {}

  ngOnInit(): void {
  }
  setRole(role:any){
    if(role===1){
      this.myRouterLink="/mobileApp"
    }
    else if(role===2){
      this.myRouterLink="/mobileApp"
    }
    else if(role===3){
      this.myRouterLink="/admin"
    }
    else if(role===4){
      this.myRouterLink="/receptionist"
    }
  }
  changeRoute(){
    if(this.myRouterLink==""){
      this.alert('Choose a role', 'danger');
    }if(!this.getData()){
      this.alert('Fill in all the data please','danger');
    }
    else{
      this.createJSON();
      this.router.navigate([this.myRouterLink]);
    }
  }

  alert(message:any, type:any) {
    const alertPlaceholder = document.getElementById('alertDiv') !  
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + 
    '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }
  getData():boolean{
    let complete:boolean=true;
    this.name= (document.getElementById("Name")! as HTMLInputElement).value;
    this.lastName= (document.getElementById("Last Name")! as HTMLInputElement).value;
    this.scndLastName= (document.getElementById("2° Last Name")! as HTMLInputElement).value;
    this.ID= (document.getElementById("ID")! as HTMLInputElement).value;
    this.email= (document.getElementById("email")! as HTMLInputElement).value;
    this.pass= (document.getElementById("password")! as HTMLInputElement).value;
    if(this.name==""||this.lastName==""||this.scndLastName==""||this.ID==""||this.email==""||this.pass==""){
      complete=false;
    }
    return complete;
  }
  createJSON(){
    let output: JSON;
    let obj: any=
    {
      "Name":this.name,
      "LName": this.lastName,
      "scndLastName": this.scndLastName,
      "ID": this.ID,
      "role": this.myRouterLink,
      "email":this.email,
      "pass":this.pass
    };
    output=<JSON>obj
    console.log(output);
  }

}