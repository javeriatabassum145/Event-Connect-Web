﻿// <auto-generated />
using System;
using Event_Connect_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_Connect_Web.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20231112164439_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event_Connect_Web.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizerUserID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.HasIndex("EventManagerID");

                    b.HasIndex("OrganizerUserID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.EventManager", b =>
                {
                    b.Property<int>("EventManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventManagerID"));

                    b.HasKey("EventManagerID");

                    b.ToTable("EventManager");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("EventID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.Event", b =>
                {
                    b.HasOne("Event_Connect_Web.Models.EventManager", null)
                        .WithMany("Events")
                        .HasForeignKey("EventManagerID");

                    b.HasOne("Event_Connect_Web.Models.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.User", b =>
                {
                    b.HasOne("Event_Connect_Web.Models.Event", null)
                        .WithMany("Attendees")
                        .HasForeignKey("EventID");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.Event", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("Event_Connect_Web.Models.EventManager", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
