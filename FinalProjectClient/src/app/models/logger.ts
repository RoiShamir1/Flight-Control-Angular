import { Leg } from './leg';

export class Logger {
  constructor(
    public id = 0,
    public leg: Leg = new Leg(),
    public flightId = 0,
    public getIn: Date = new Date(),
    public getOut: Date = new Date()
  ) {}
}
