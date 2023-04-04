import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateForm'
})
export class DateFormatPipe implements PipeTransform {
  transform(value: string): string {
    const date = new Date(value);
    const formattedDate = date.toISOString().replace('T', ' ').replace(/\.\d+Z$/, '');
    return formattedDate;
  }
}

