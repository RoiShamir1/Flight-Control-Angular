import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
// import { LoggerComponent } from './loggers/logger/logger.component';
import { LoggerListComponent } from './loggers/logger-list/logger-list.component';
import { LoggerFullDetailsComponent } from './loggers/logger-full-details/logger-full-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoggersModule } from './loggers/loggers.module';
import { routing } from './app-routing.module';


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    LoggersModule,
    routing,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
