import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Logger } from 'src/app/models/logger';
import { LoggerService } from '../services/logger.service';

@Component({
  selector: 'app-logger-full-details',
  templateUrl: './logger-full-details.component.html',
  styleUrls: ['./logger-full-details.component.css'],
})
export class LoggerFullDetailsComponent {
  logger: Logger = new Logger();

  @Input() logger2: Logger = new Logger();
  @Output() onDelete = new EventEmitter<any>();

  deleteHandler() {
    this.onDelete.emit(this.logger2.id);
  }

  constructor(
    private route: ActivatedRoute,
    private loggerService: LoggerService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      let id = params['id'];
      this.loggerService.getById(id).subscribe((data) => {
        this.logger = data as Logger;
      });
    });
  }
}
