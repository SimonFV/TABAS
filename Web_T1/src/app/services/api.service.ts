import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  getItem(){
    let header =new HttpHeaders().set('Type-contet','aplication/json');
    return this.http.get('https://localhost:5001/employee', {headers: header});
  }
  postRegister(employee:JSON){
    let header =new HttpHeaders().set('Type-contet','aplication/json');
    return this.http.post('https://localhost:5001/employee/register', employee,{headers: header});
  }
  postLogin(employee:JSON){
    let header =new HttpHeaders().set('Type-contet','aplication/json');
    return this.http.post('https://localhost:5001/employee/login', employee,{headers: header});
  }
}
