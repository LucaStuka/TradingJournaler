import { provideServerRendering } from '@angular/platform-server';
import { provideRouter, Routes } from '@angular/router';
import { withViewTransitions } from '@angular/router';
import { TradesListComponent } from './components/trades-list/trades-list';

export const serverRoutes: Routes = [
  { path: '', component: TradesListComponent }
];

export const provideServerRoutes = [
  provideRouter(serverRoutes, withViewTransitions()),
  provideServerRendering()
];
