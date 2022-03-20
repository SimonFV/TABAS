import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
import { APIService } from '../services/api.service';

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  myRouterLink = ""
  role = 0
  Name: any;
  pass: any;
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: APIService
  ) { }

  ngOnInit(): void {
  }
  setRole(role: any) {
    if (role === 1) {
      this.myRouterLink = "/mobileApp"
      this.role = 1
    }
    else if (role === 2) {
      this.myRouterLink = "/mobileApp"
      this.role = 2
    }
    else if (role === 3) {
      this.myRouterLink = "/admin"
      this.role = 3
    }
    else if (role === 4) {
      this.myRouterLink = "/receptionist"
      this.role = 4
    }
  }
  changeRoute() {
    this.service.postLogin(this.createJSON()).subscribe(resp => {
      console.log(resp);
      this.router.navigate([this.myRouterLink]);
    },
      (err) => {
        console.log(err);
      });

  }

  alert(message: any, type: any) {
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

  getData() {
    this.Name = (document.getElementById("Name")! as HTMLInputElement).value;
    this.pass = (document.getElementById("password")! as HTMLInputElement).value;

    if (this.Name == "" || this.pass == "") {
      this.alert('Fill in all the data please', 'danger');
    }
    else if (this.role == 0) {
      this.alert('Choose a role', 'danger')
    } else {
      this.changeRoute();
    }
    return false;
  }
  createJSON(): JSON {
    let output: JSON;
    let obj: any =
    {
      "nombre": this.Name,
      "password": this.pass,
      "nombre_rol": this.myRouterLink.substring(1)
    };
    output = <JSON>obj
    console.log(output);
    return output;
  }

}

