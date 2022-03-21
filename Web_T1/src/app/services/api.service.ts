import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http: HttpClient) { }

  getItem() {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.get('http://localhost:5001/employee', { headers: header });
  }
  getBaggage() {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.get('http://localhost:5001/baggage', { headers: header });
  }
  getBagCar() {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.get('http://localhost:5001/bagcar', { headers: header });
  }
  getFlights() {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.get('http://localhost:5001/flights', { headers: header });
  }

  postRegister(employee: JSON) {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post('http://localhost:5001/employee/register', employee, { headers: header });
  }
  postLogin(employee: JSON) {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post('http://localhost:5001/employee/login', employee, { headers: header });
  }

  postLoginHeaders(employee: JSON) {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post('http://localhost:5001/employee/login', employee, { headers: header });
  }
  postBaggage(bag: JSON) {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post('http://localhost:5001/baggage', bag, { headers: header });
  }

  postAssignment(assignment: JSON) {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.put('http://localhost:5001/cartoflight', assignment, { headers: header });

  }
}
