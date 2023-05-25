import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-customer-form',
  templateUrl: './new-customer-form.component.html',
  styleUrls: ['./new-customer-form.component.scss']
})
export class NewCustomerFormComponent {

  constructor(
    private router: Router,
    private httpClient: HttpClient
  ) { }
  
  newCustomer: NewCustomer = {
    firstName: null,
    lastName: null,
    email: null,
    mobile: null,
    address: null
  };

  addCustomer() {
    this.httpClient
      .post(
        'https://localhost:44351/api/customer/',
        JSON.stringify(this.newCustomer),
        { headers: { 'Content-Type': 'application/json'} }
      )
      .subscribe(_ => this.router.navigateByUrl('/customers'));
  }

}

export type NewCustomer = {
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  mobile: string | null;
  address: string | null;
}
