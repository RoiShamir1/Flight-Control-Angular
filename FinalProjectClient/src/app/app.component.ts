import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Logger } from './models/logger';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'FinalProjectClient';

  // @Input() logger: Logger = new Logger();
  // @Output() onDelete = new EventEmitter<any>();

  // deleteHandler() {
  //   this.onDelete.emit(this.logger.id);
  // }
}
