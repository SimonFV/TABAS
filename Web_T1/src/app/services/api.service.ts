import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  getItem(){
    let header =new HttpHeaders().set('Type-contet','aplication/json');
    return this.http.get('https://localhost:5001/items/7f4316f4-c18b-4a6a-bfd6-5d6d7193cac6', {headers: header});
  }
}
