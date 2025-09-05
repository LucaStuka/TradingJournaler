import { Routes } from '@angular/router';
import { TradesListComponent } from './components/trades-list/trades-list';

export const routes: Routes = [
  {
    path: 'trades',
    component: TradesListComponent,
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'trades',
  },
];