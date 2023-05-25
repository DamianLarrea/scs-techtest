import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NewCustomer } from '../NewCustomer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-new-customer-form',
  templateUrl: './new-customer-form.component.html',
  styleUrls: ['./new-customer-form.component.scss']
})
export class NewCustomerFormComponent {

  constructor(
    private router: Router,
    private customerService: CustomerService
  ) { }
  
  newCustomer: NewCustomer = {
    firstName: null,
    lastName: null,
    email: null,
    mobile: null,
    address: null
  };

  addCustomer() {
    this.customerService
      .createCustomer(this.newCustomer)
      .subscribe(_ => this.router.navigateByUrl('/customers'))
  }

}
