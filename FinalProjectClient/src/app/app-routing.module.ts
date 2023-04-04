import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoggerFullDetailsComponent } from './loggers/logger-full-details/logger-full-details.component';
import { LoggerListComponent } from './loggers/logger-list/logger-list.component';

const routes: Routes = [
  { path: '', component: LoggerListComponent },
  { path: 'loggers', component: LoggerListComponent },
  { path: 'loggers/:id', component: LoggerFullDetailsComponent },
];

export const routing = RouterModule.forRoot(routes);

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
