import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TradeService } from '../../services/trade.service';
import { Trade } from '../../models/trade.model';

@Component({
  selector: 'app-trade-detail',
  templateUrl: './trade-detail.component.html',
  styleUrls: ['./trade-detail.component.css']
})
export class TradeDetailComponent implements OnInit {
  trade: Trade | undefined;

  constructor(private tradeService: TradeService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getTradeDetail();
  }

  getTradeDetail(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.tradeService.getTradeById(id).subscribe(trade => {
      this.trade = trade;
    });
  }
}