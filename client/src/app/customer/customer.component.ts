import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { response } from 'express';
import { SocketAddress } from 'net';
import { identity } from 'rxjs';

interface Customer {
  id: number;
  customerName: string;
  address: string;
  contactInformation: string;
}
@Component({
  selector: 'app-customer',
  imports: [],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {
  customers: Customer[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers() {
    this.http.get<Customer[]>('http://localhost:5235/api/customer')
    .subscribe(response => {
      this.customers = response;
      const tableBody = document.getElementById('customer-table-body');
      if (tableBody) {
        this.customers.forEach((customer: Customer) => {
          const row = `
          <tr>
            <td>${customer.id}</td>
            <td>${customer.customerName}</td>
            <td>${customer.address}</td>
            <td>${customer.contactInformation}</td>
          </tr>
        `;
        tableBody.innerHTML += row;
        });
      } else {
        console.error('Table body not found');
      }
    });
  }
}