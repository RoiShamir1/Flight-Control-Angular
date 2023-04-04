import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Logger } from 'src/app/models/logger';
import { LoggerService } from '../services/logger.service';

@Component({
  selector: 'app-logger-list',
  templateUrl: './logger-list.component.html',
  styleUrls: ['./logger-list.component.css'],
})
export class LoggerListComponent {
  loggers: Logger[] = [];
  newLogger: Logger = new Logger();

  @Input() logger: Logger = new Logger();
  @Output() onDelete = new EventEmitter<any>();

  errorMessage = '';

  constructor(private loggerService: LoggerService, private router: Router) {
    loggerService.get().subscribe({
      next: (data) => {
        this.loggers = data as Logger[];
      },
      error: (error) => {
        this.errorMessage = 'Some error occurred, please try again';
      },
    });
  }

  deleteLogger(id: number) {
    this.loggerService.delete(id).subscribe({
      next: (data) => {
        this.loggers = this.loggers.filter((p) => p.id != id);
      },
      error: (error) => {
        this.errorMessage = 'Delete failed, please try again';
      },
    });
  }

  ngOnInit() {
    setTimeout(() => {
      window.location.reload();
    }, 10000);
  }

}
