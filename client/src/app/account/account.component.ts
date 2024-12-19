import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Account {
  id: number;
  accountNumber: string;
  accountName: string;
  accountType: string;
}

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'], 
  standalone: true,
})
export class AccountComponent implements OnInit {
  accounts: Account[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getAccounts();
  }

  
  getAccounts() {
    this.http.get<Account[]>('http://localhost:5083/api/account')
      .subscribe(response => {
        this.accounts = response;
        const tableBody = document.getElementById('accounts-table-body');
        if (tableBody) {
          this.accounts.forEach((account: Account) => {
            const row = `
              <tr>
                <td>${account.id}</td>
                <td>${account.accountNumber}</td>
                <td>${account.accountName}</td>
                <td>${account.accountType}</td>
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