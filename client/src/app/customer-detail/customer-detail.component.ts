import { Component, OnInit } from '@angular/core';
import { Customer } from '../Customer';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    var customerId = this.route.snapshot.params['id'];
    this.customerService.getCustomer(customerId)
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
