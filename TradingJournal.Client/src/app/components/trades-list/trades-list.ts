import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TradeService } from '../../services/trade-service';
import { Trade } from '../../models/trade';

@Component({
  selector: 'app-trades-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './trades-list.html',
})
export class TradesListComponent {
  trades: Trade[] = [
    {
      id: 1,
      entryDate: "testDate",
      entryPrice: 5,
      quantity: 5,
      symbol: "Fortntie"
    },
    {
      id: 2,
      entryDate: "testDate",
      entryPrice: 5,
      quantity: 5,
      symbol: "NQ1!"
    },
    {
      id: 3,
      entryDate: "testDate",
      entryPrice: 5,
      quantity: 5,
      symbol: "ES500"
    },
    {
      id: 4,
      entryDate: "testDate",
      entryPrice: 5,
      quantity: 5,
      symbol: "KeinePlan"
    },
  ];
  loading: boolean = true;
  error: string | null = null;   // <--- hinzufügen

  constructor(private tradeService: TradeService) {}

  ngOnInit() {
    // this.tradeService.getTrades().subscribe({
    //   next: (data) => {
    //     this.trades = data;
    //     this.loading = false;
    //   },
    //   error: (err) => {
    //     this.error = 'Failed to load trades. Please try again later.';
    //     console.error(err);
    //     this.loading = false;
    //   }
    // });
    this.delay(500)
    this.loading = false;
  }

  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
