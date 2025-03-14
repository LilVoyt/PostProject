using Microsoft.EntityFrameworkCore;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<TrackLog> TrackLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentId)
                    .HasPrincipalKey(d => d.Id);
            });


            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("CHK_Constraint_PhoneNumber", "PhoneNumber LIKE '+380%' AND LEN(PhoneNumber) = 13");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.HasOne(s => s.DepartmentSender)
                    .WithMany(d => d.DepartingShipment)
                    .HasForeignKey(s => s.DepartmentSenderId);

                entity.HasOne(s => s.DepartmentReceiver)
                    .WithMany(d => d.IncomingShipment)
                    .HasForeignKey(s => s.DepartmentReceiverId);

                entity.HasOne(s => s.ClientSender)
                    .WithMany(c => c.SentShipments)
                    .HasForeignKey(s => s.ClientSenderId);

                entity.HasOne(s => s.ClientReceiver)
                    .WithMany(c => c.ReceivedShipments)
                    .HasForeignKey(s => s.ClientReceiverId);

                entity.HasIndex(s => s.TrackId)
                    .IsUnique();
            });

            modelBuilder.Entity<TrackLog>(entity =>
            {
                entity.HasOne(t => t.Shipment)
                    .WithMany(s => s.TrackLogs)
                    .HasForeignKey(t => t.TrackId)
                    .HasPrincipalKey(s => s.TrackId);
            });

            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasOne(b => b.Shipment)
                .WithMany(s => s.Boxes)
                .HasForeignKey(b => b.ShipmentId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
