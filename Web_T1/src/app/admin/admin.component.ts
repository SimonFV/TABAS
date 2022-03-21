import { Component, OnInit } from '@angular/core';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  bagCartID: any;
  flightID: any;
  constructor(private service: APIService) { }

  ngOnInit(): void {
  }
  alert(message: any, type: any) {
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }
  getData() {
    this.bagCartID = (document.getElementById("Bagcart ID")! as HTMLInputElement).value;
    this.flightID = (document.getElementById("Flight ID")! as HTMLInputElement).value;
    if (this.bagCartID == "" || this.flightID == "") {
      this.alert('Fill in all the data please', 'danger');
    } else {
      this.service.postAssignment(this.createJSON()).subscribe(resp => {
        this.alert('Bagcart assigned', 'success');
        console.log(resp);
      },
        (err) => {
          console.log(err);
          this.alert('Invalid Car or Flight', 'danger');
        })
    }

  }
  createJSON(): JSON {
    let output: JSON;
    let obj: any =
    {
      "idBagCar": this.bagCartID,
      "idVuelo": this.flightID
    };
    output = <JSON>obj
    return output;
  }

}
