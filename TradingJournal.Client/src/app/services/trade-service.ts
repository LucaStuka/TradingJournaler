import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Trade } from '../models/trade';

@Injectable({
  providedIn: 'root'
})
export class TradeService {
  private apiUrl = 'http://localhost:5000/api/trades'; // <- URL zu deinem Backend

  // constructor(private http: HttpClient) {}

  // getTrades(): Observable<Trade[]> {
  //   return this.http.get<Trade[]>(this.apiUrl);
  // }
}
