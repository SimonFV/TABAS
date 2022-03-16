import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  myRouterLink = " "
  role=0
  email:any;
  pass:any;
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router) {}

  ngOnInit(): void {
  }
  setRole(role:any){
    if(role===1){
      this.myRouterLink="/mobileApp"
      this.role=1
    }
    else if(role===2){
      this.myRouterLink="/mobileApp"
      this.role=2
    }
    else if(role===3){
      this.myRouterLink="/admin"
      this.role=3
    }
    else if(role===4){
      this.myRouterLink="/receptionist"
      this.role=4
    }
  }

  changeRoute(){
    this.createJSON();
    this.router.navigate([this.myRouterLink]);
  }

  alert(message:any, type:any) {
    const alertPlaceholder = document.getElementById('alertDiv') !  
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + 
    '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

  getData(){
    this.email= (document.getElementById("email")! as HTMLInputElement).value;
    this.pass= (document.getElementById("password")! as HTMLInputElement).value;
    
    if(this.email==""||this.pass==""){
      console.log("DATA");
      this.alert('Fill in all the data please','danger');
    }
    else if (this.role==0){
      console.log("ROLE");
      this.alert('Choose a role', 'danger')
    }else{
      console.log("ELSE");
      this.changeRoute();
    }
  }
  createJSON(){
    let output: JSON;
    let obj: any=
    {
      "email":this.email,
      "pass":this.pass
    };
    output=<JSON>obj
    console.log(output);
  }

}

