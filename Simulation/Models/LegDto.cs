using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Models
{
    public class LegDto
    {
        public int Number { get; set; }
        public int WaitTime { get; set; }
        public virtual FlightDto? Flight { get; set; }
        public LegNumber CurrentLeg { get; set; }
        public LegNumber NextLegs { get; set; }
        public bool IsChangeStatus { get; set; }
    }

    [Flags]
    public enum LegNumber
    {
        One = 0b000000001,   //1
        Two = 0b000000010,   //2
        Thr = 0b000000100,   //4
        Fou = 0b000001000,   //8
        Fiv = 0b000010000,
        Six = 0b000100000,
        Sev = 0b001000000,
        Eig = 0b010000000,
        Dep = 0b100000000,
    }
}
