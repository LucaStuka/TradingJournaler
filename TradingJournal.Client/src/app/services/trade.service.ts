import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Trade } from '../models/trade';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TradeService  {
  private url = environment.apiUrl

  constructor(private http: HttpClient) { }

  getTrades(): Observable<Trade[]> {
    return this.http.get<Trade[]>(this.url + "/Trades")
  }
}
