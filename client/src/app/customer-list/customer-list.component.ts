import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Customer } from '../Customer';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  constructor(private httpClient: HttpClient) {}

  customers: Observable<Customer[]> | null = null;

  ngOnInit(): void {
    this.customers = this.httpClient.get<Customer[]>('https://localhost:44351/api/customer/');
  }
}
