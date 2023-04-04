using FinalProjectASP.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectASP.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }  

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Leg>().HasData(
        //     new Leg { Id = 1, Number = 1, WaitTime = 3, IsChangeStatus = false, CurrentLeg = LegNumber.One, NextLegs = LegNumber.Two },
        //     new Leg { Id = 2, Number = 2, WaitTime = 5, IsChangeStatus = false, CurrentLeg = LegNumber.Two, NextLegs = LegNumber.Thr },
        //     new Leg { Id = 3, Number = 3, WaitTime = 6, IsChangeStatus = false, CurrentLeg = LegNumber.Thr, NextLegs = LegNumber.Fou },
        //     new Leg { Id = 4, Number = 4, WaitTime = 7, IsChangeStatus = false, CurrentLeg = LegNumber.Fou, NextLegs = LegNumber.Fiv | LegNumber.Dep },
        //     new Leg { Id = 5, Number = 5, WaitTime = 4, IsChangeStatus = false, CurrentLeg = LegNumber.Fiv, NextLegs = LegNumber.Six | LegNumber.Sev },
        //     new Leg { Id = 6, Number = 6, WaitTime = 7, IsChangeStatus = true, CurrentLeg = LegNumber.Six, NextLegs = LegNumber.Eig },
        //     new Leg { Id = 7, Number = 7, WaitTime = 8, IsChangeStatus = true, CurrentLeg = LegNumber.Sev, NextLegs = LegNumber.Eig },
        //     new Leg { Id = 8, Number = 8, WaitTime = 2, IsChangeStatus = true, CurrentLeg = LegNumber.Eig, NextLegs = LegNumber.Fou }
        //        );
        //}
    }
}
