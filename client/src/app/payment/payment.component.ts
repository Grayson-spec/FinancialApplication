import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { response } from 'express';

interface Payment {
  id: number;
  paymentDate: Date;
  paymentMethod: string;
  paymentAmount: number;
  invoiceId: number;
}

@Component({
  selector: 'app-payment',
  imports: [],
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.css'
})

export class PaymentComponent {
  payments: Payment[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getPayments();
  }

  getPayments() {
    this.http.get<Payment[]>('http://localhost:5235/api/payment')
    .subscribe(response => {
      this.payments = response;
      const tableBody = document.getElementById('payment-history-table');
      if (tableBody) {
        this.payments.forEach((payment: Payment) => {
          const row = `
          <tr>
            <td>${payment.id}</td>
            <td>${payment.paymentDate}</td>
            <td>${payment.paymentMethod}</td>
            <td>${payment.paymentAmount}</td>
            <td>${payment.invoiceId}</td>
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