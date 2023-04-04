export class Leg {
  constructor(
    public id = 0,
    public number = 0,
    public waitTime = 0,
    public flightId = 0,
    public currentLeg: LegNumber = 1,
    public nextLegs: LegNumber = 2,
    public isChangeStatus = false
  ) {}
}

enum LegNumber {
  One = 0b000000001,
  Two = 0b000000010,
  Thr = 0b000000100,
  Fou = 0b000001000,
  Fiv = 0b000010000,
  Six = 0b000100000,
  Sev = 0b001000000,
  Eig = 0b010000000,
  Dep = 0b100000000,
}
