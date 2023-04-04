import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { catchError, Observable } from 'rxjs';

@Injectable()
export class LoggerService {
  
  private api = 'https://localhost:7097/api/loggers';

  //private api = 'http://localhost:3000/loggers';

  constructor(private httpClient: HttpClient) {}

  get() {
    return this.httpClient.get(this.api);
  }

  getById(id: number) {
    return this.httpClient.get(`${this.api}/${id}`);
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.api}/${id}`);
  }
}
