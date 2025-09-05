import { ApplicationConfig } from '@angular/core';
import { provideServerRoutes } from './app.routes.server';

export const appConfigServer: ApplicationConfig = {
  providers: [
    ...provideServerRoutes
  ]
};