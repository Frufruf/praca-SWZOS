﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWZOS_Database;

#nullable disable

namespace SWZOS.Migrations
{
    [DbContext(typeof(SWZOSContext))]
    [Migration("20220205172548_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SWZOS_Database.Entities.BlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BLACK_LIST_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("REASON");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("STATUS");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BLACK_LIST", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.BlackListStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BLACK_LIST_STATUS_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("BLACK_LIST_STATUS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ITEM_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.HasKey("Id");

                    b.ToTable("EQUIPMENT", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<double>("Fee")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)")
                        .HasColumnName("FEE");

                    b.Property<bool>("IsSettled")
                        .HasColumnType("bit")
                        .HasColumnName("IS_SETTLED");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("RESERVATION_ID");

                    b.HasKey("PaymentId");

                    b.HasIndex("ReservationId");

                    b.ToTable("PAYMENTS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Pitch", b =>
                {
                    b.Property<int>("PitchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PITCH_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PitchId"), 1L, 1);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit")
                        .HasColumnName("ACTIVE_FLAG");

                    b.Property<string>("Desription")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("PitchTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PITCH_TYPE_ID");

                    b.Property<double>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)")
                        .HasColumnName("PRICE");

                    b.HasKey("PitchId");

                    b.HasIndex("PitchTypeId");

                    b.ToTable("PITCHES", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PitchType", b =>
                {
                    b.Property<int>("PitchTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PITCH_TYPE_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PitchTypeId"), 1L, 1);

                    b.Property<string>("PitchTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PitchTypeName");

                    b.HasKey("PitchTypeId");

                    b.ToTable("PITCH_TYPES", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RESERVATION_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("PitchId")
                        .HasColumnType("int")
                        .HasColumnName("PITCH_ID");

                    b.Property<int>("ReservationDuration")
                        .HasColumnType("int")
                        .HasColumnName("DURATION");

                    b.Property<double>("ReservationPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)")
                        .HasColumnName("PRICE");

                    b.Property<DateTime>("ReservationStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("START_DATE");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("int")
                        .HasColumnName("STATUS");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("ReservationId");

                    b.HasIndex("PitchId");

                    b.HasIndex("UserId");

                    b.ToTable("RESERVATIONS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("LOGIN");

                    b.Property<string>("MailAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL_ADDRESS");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("PESEL")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("PESEL");

                    b.Property<DateTime>("PasswordExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("PASSWORD_EXPIRATION_DATE");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSWORD_SALT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SURNAME");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("USER_TYPE_ID");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_TYPE_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("USER_TYPES", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.BlackList", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.BlackListStatus", "BlackListStatus")
                        .WithMany("BlackList")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.User", "User")
                        .WithOne("BlackList")
                        .HasForeignKey("SWZOS_Database.Entities.BlackList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlackListStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Payment", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.Reservation", "Reservation")
                        .WithMany("Payments")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Pitch", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.PitchType", "PitchType")
                        .WithMany("Pitches")
                        .HasForeignKey("PitchTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PitchType");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Reservation", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.Pitch", "Pitch")
                        .WithMany("Reservations")
                        .HasForeignKey("PitchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pitch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.User", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.BlackListStatus", b =>
                {
                    b.Navigation("BlackList");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Pitch", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PitchType", b =>
                {
                    b.Navigation("Pitches");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Reservation", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.User", b =>
                {
                    b.Navigation("BlackList");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
