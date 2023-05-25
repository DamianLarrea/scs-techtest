import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './Customer';
import { NewCustomer } from './NewCustomer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>('https://localhost:44351/api/customer/');
  }

  getCustomer(id: string): Observable<Customer> {
    return this.httpClient.get<Customer>(encodeURI(`https://localhost:44351/api/customer/${id}`));
  }

  createCustomer(newCustomer: NewCustomer): Observable<any> {
    return this.httpClient.post(
      'https://localhost:44351/api/customer/',
      JSON.stringify(newCustomer),
      { headers: { 'Content-Type': 'application/json'} }
    );
  }
}
