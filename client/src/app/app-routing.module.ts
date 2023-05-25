import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewCustomerFormComponent } from './new-customer-form/new-customer-form.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/customers', pathMatch: 'full'},
  { path: 'customers', component: CustomerListComponent },
  { path: 'customers/new', component: NewCustomerFormComponent },
  { path: 'customers/:id', component: CustomerDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
