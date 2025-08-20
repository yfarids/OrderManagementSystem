import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  template: `
    <h2>Home Page</h2>
    <p>This is the home component.</p>
    <a routerLink="/orders">Go to Orders</a>
  `
})
export class HomeComponent {
}
