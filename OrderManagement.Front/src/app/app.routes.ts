import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: '/orders', pathMatch: 'full' },
  { 
    path: 'orders', 
    loadComponent: () => import('./orders/order-list/order-list').then(m => m.OrderList)
  },

{ 
    path: 'home', 
    loadComponent: () => import('./home/home.component').then(m => m.HomeComponent)
  },
];