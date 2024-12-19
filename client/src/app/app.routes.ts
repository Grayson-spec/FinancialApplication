import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AccountComponent } from './account/account.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AboutComponent } from './about/about.component';
import { CustomerComponent } from './customer/customer.component';
import { VendorComponent } from './vendor/vendor.component';
import { TransactionComponent } from './transaction/transaction.component';
import { SalesComponent } from './sales/sales.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { PaymentComponent } from './payment/payment.component';

export const routes = [
  { path: '', component: HomeComponent },
  { path: 'account', component: AccountComponent },
  { path: 'dashboard', component: DashboardComponent},
  {path: 'about', component:AboutComponent},
  {path: 'customer', component:CustomerComponent},
  { path: 'payment', component:PaymentComponent },
  { path: 'purchase', component:PurchaseComponent},
  {path: 'sales', component:SalesComponent},
  {path: 'transaction', component:TransactionComponent},
  {path: 'vendor', component:VendorComponent},
];

export const appRoutes = RouterModule.forRoot(routes);