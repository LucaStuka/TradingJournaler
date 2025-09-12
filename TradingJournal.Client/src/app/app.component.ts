import { Component } from '@angular/core';
import { TradeJournalListComponent } from "./components/trade-journal-list/trade-journal-list.component";

@Component({
  selector: 'app-root',
  imports: [TradeJournalListComponent], // <-- hier würde dann RouterOutlet hinkommen
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'TradingJournal.Client';
}
