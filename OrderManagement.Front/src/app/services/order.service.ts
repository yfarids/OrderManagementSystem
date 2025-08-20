import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'http://localhost:5128/api/orders';

  constructor(private http: HttpClient) {}

  getRecentOrders(days: number = 7): Observable<any> {
    return this.http.get(`${this.apiUrl}/recent?days=${days}`);
  }
}
