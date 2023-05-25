import { Component, OnInit } from '@angular/core';
import { Customer } from '../Customer';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    var customerId = this.route.snapshot.params['id'];
    this.httpClient.get<Customer>(`https://localhost:44351/api/customer/${customerId}`)
      .subscribe(response => this.customer = response);
  }

  customer: Customer = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    mobile: '',
    address: ''
  };

}
