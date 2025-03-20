﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostProject.DataAcces.Data;

#nullable disable

namespace PostProject.DataAcces.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250320091616_passwordAdded")]
    partial class passwordAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostProject.DataAcces.Entities.Box", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("ShipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientSenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentSenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientReceiverId");

                    b.HasIndex("ClientSenderId");

                    b.HasIndex("DepartmentReceiverId");

                    b.HasIndex("DepartmentSenderId");

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.TrackLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProceedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackLogs");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Box", b =>
                {
                    b.HasOne("PostProject.DataAcces.Entities.Shipment", "Shipment")
                        .WithMany("Boxes")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Employee", b =>
                {
                    b.HasOne("PostProject.DataAcces.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Shipment", b =>
                {
                    b.HasOne("PostProject.DataAcces.Entities.Client", "ClientReceiver")
                        .WithMany("ReceivedShipments")
                        .HasForeignKey("ClientReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PostProject.DataAcces.Entities.Client", "ClientSender")
                        .WithMany("SentShipments")
                        .HasForeignKey("ClientSenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PostProject.DataAcces.Entities.Department", "DepartmentReceiver")
                        .WithMany("IncomingShipment")
                        .HasForeignKey("DepartmentReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PostProject.DataAcces.Entities.Department", "DepartmentSender")
                        .WithMany("DepartingShipment")
                        .HasForeignKey("DepartmentSenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientReceiver");

                    b.Navigation("ClientSender");

                    b.Navigation("DepartmentReceiver");

                    b.Navigation("DepartmentSender");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.TrackLog", b =>
                {
                    b.HasOne("PostProject.DataAcces.Entities.Shipment", "Shipment")
                        .WithMany("TrackLogs")
                        .HasForeignKey("TrackId")
                        .HasPrincipalKey("TrackId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Client", b =>
                {
                    b.Navigation("ReceivedShipments");

                    b.Navigation("SentShipments");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Department", b =>
                {
                    b.Navigation("DepartingShipment");

                    b.Navigation("Employees");

                    b.Navigation("IncomingShipment");
                });

            modelBuilder.Entity("PostProject.DataAcces.Entities.Shipment", b =>
                {
                    b.Navigation("Boxes");

                    b.Navigation("TrackLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
