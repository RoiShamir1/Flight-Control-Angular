import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { LoggerComponent } from './logger/logger.component';
import { LoggerFullDetailsComponent } from './logger-full-details/logger-full-details.component';
import { LoggerListComponent } from './logger-list/logger-list.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoggerService } from './services/logger.service';
import { DateFormatPipe } from '../pipes/date-form.pipe';

@NgModule({
  declarations: [
    // LoggerComponent,
    LoggerFullDetailsComponent,
    LoggerListComponent,
    DateFormatPipe,
  ],
  imports: [CommonModule, FormsModule, RouterModule],
  providers: [LoggerService],
  exports: [LoggerListComponent],
})
export class LoggersModule {}
