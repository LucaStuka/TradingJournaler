import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Trade } from '../../models/trade';
import { TradeService } from '../../services/trade.service';

@Component({
  selector: 'app-trade-journal-list',
  templateUrl: './trade-journal-list.component.html',
  standalone: true,
  imports: [NgFor]
})
export class TradeJournalListComponent implements OnInit {
  trades: Trade[] = [];

  constructor(public service: TradeService) {}

  ngOnInit(): void {
    this.getData()
  }

  getData() {
    this.service.getTrades().subscribe({
      next: (res) => {
        this.trades = res
      },
      error: (err) => {
        console.log(err)
      }
    })
  }
}