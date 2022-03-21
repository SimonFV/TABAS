import { Component, OnInit } from '@angular/core';
import { APIService } from '../services/api.service';
@Component({
  selector: 'app-baggage',
  templateUrl: './baggage.component.html',
  styleUrls: ['./baggage.component.css']
})
export class BaggageComponent implements OnInit {
  user: any;
  color: any;
  weight: any;
  cost: any;
  flight: any;
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
    this.user = (document.getElementById("user")! as HTMLInputElement).value;
    this.color = (document.getElementById("color")! as HTMLInputElement).value;
    this.weight = (document.getElementById("weight")! as HTMLInputElement).value;
    this.cost = (document.getElementById("cost")! as HTMLInputElement).value;
    this.flight = (document.getElementById("flight")! as HTMLInputElement).value;
    if (this.user == "" || this.color == "" || this.weight == "" || this.cost == "" || this.flight == "") {
      this.alert('Fill in all the data please', 'danger');
    } else {
      this.service.postBaggage(this.createJSON()).subscribe(resp => {
        console.log(resp);
        this.alert('Bag registered', 'success');
      },
        (err) => {
          console.log(err);
          this.alert('Invalid flight', 'danger');
        })

    }
  }
  createJSON(): JSON {
    let output: JSON;
    let obj: any =
    {
      "usuario_cedula": this.user,
      "costo": this.cost,
      "peso": this.weight,
      "color": this.color,
      "idVuelo": this.flight
    };
    output = <JSON>obj
    console.log(output);
    return output;
  }

}
