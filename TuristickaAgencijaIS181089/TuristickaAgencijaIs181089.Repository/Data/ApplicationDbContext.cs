using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

using TuristickaAgencijaIS181089.Domain.Identity;


namespace TuristickaAgencijaIS181089.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<TuristickaAgencijaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }


        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservedLine> ReservedLines { get; set; }
        public virtual DbSet<OrderedLine> OrderedLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Line>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Destination>()
              .Property(z => z.Id)
              .ValueGeneratedOnAdd();
            builder.Entity<Company>()
              .Property(z => z.Id)
              .ValueGeneratedOnAdd();

            builder.Entity<Reservation>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();


            builder.Entity<ReservedLine>()
                .HasOne(z => z.Line)
                .WithMany(z => z.ReservedLines)
                .HasForeignKey(z => z.LineId);

            builder.Entity<Line>()
           .HasOne(z => z.StartingDestination)
           .WithMany(z => z.LinesS)
           .HasForeignKey(z => z.StartingDestinationId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Line>()
         .HasOne(z => z.FinalDestination)
         .WithMany(z => z.LinesF)
         .HasForeignKey(z => z.FinalDestinationId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Line>()
       .HasOne(z => z.Company)
       .WithMany(z => z.Lines)
       .HasForeignKey(z => z.CompanyId);



            builder.Entity<ReservedLine>()
                .HasOne(z => z.Reservation)
                .WithMany(z => z.ReservedLines)
                .HasForeignKey(z => z.ReservationId);


            builder.Entity<Reservation>()
                .HasOne<TuristickaAgencijaUser>(z => z.Owner)
                .WithOne(z => z.UserReservation)
                .HasForeignKey<Reservation>(z => z.OwnerId);
            builder.Entity<Order>()
         .HasOne(z => z.User)
         .WithMany(z => z.Orders)
         .HasForeignKey(z => z.UserId);

            builder.Entity<OrderedLine>()
                .HasOne(z => z.LineInOrder)
                .WithMany(z => z.OrderedLines)
                .HasForeignKey(z => z.LineId);

            builder.Entity<OrderedLine>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.OrderedLines)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
