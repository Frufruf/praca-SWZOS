﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWZOS_Database;

#nullable disable

namespace SWZOS.Migrations
{
    [DbContext(typeof(SWZOSContext))]
    partial class SWZOSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUsers");
                });

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
                        .HasColumnName("STATUS_ID");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Waiting for approval"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deleted"
                        });
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ITEM_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("MaximumQuantityPerReservation")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRICE");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.HasKey("Id");

                    b.ToTable("EQUIPMENT", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Piłka do piłki nożnej o rozmiarze 5",
                            MaximumQuantityPerReservation = 9,
                            Name = "Piłka do piłki nożnej",
                            Price = 3m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 2,
                            Description = "Piłka do koszykówki",
                            MaximumQuantityPerReservation = 10,
                            Name = "Piłka do koszykówki",
                            Price = 3m,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 3,
                            Description = "Piłka do siatkówki",
                            MaximumQuantityPerReservation = 10,
                            Name = "Piłka do siatkówki",
                            Price = 1.5m,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 4,
                            Description = "Piłka do tenisa",
                            MaximumQuantityPerReservation = 30,
                            Name = "Piłka do tenisa",
                            Price = 0m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 5,
                            Description = "Koszulka sportowa",
                            MaximumQuantityPerReservation = 18,
                            Name = "Czerwone koszulki do gry",
                            Price = 1.5m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 6,
                            Description = "Koszulka sportowa",
                            MaximumQuantityPerReservation = 18,
                            Name = "Niebieskie koszulki do gry",
                            Price = 1.5m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 7,
                            Description = "Koszulka sportowa",
                            MaximumQuantityPerReservation = 18,
                            Name = "Białe koszulki do gry",
                            Price = 1.5m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 8,
                            Description = "Koszulka sportowa",
                            MaximumQuantityPerReservation = 18,
                            Name = "Czarne koszulki do gry",
                            Price = 1.5m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 9,
                            Description = "Rakieta do gry w tenisa",
                            MaximumQuantityPerReservation = 4,
                            Name = "Rakieta tenisowa",
                            Price = 10m,
                            Quantity = 24
                        });
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<decimal?>("AdvancePayment")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ADVANCE_PAYMENT");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<decimal>("FullFee")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("FULL_FEE");

                    b.Property<decimal>("PaidInAmmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PAID_IN_AMMOUNT");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("RESERVATION_ID");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_STATUS_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("PaymentId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("PAYMENTS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("PaymentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_STATUS_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentStatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("PaymentStatusId");

                    b.ToTable("PAYMENTS_STATUS", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PERMISSION_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"), 1L, 1);

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit")
                        .HasColumnName("DELETED_FLAG");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("PermissionId");

                    b.ToTable("PERMISSIONS", (string)null);
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

                    b.HasKey("PitchId");

                    b.HasIndex("PitchTypeId");

                    b.ToTable("PITCHES", (string)null);

                    b.HasData(
                        new
                        {
                            PitchId = 1,
                            ActiveFlag = true,
                            Desription = "Boisko do piłki nożnej",
                            PitchTypeId = 1
                        },
                        new
                        {
                            PitchId = 2,
                            ActiveFlag = true,
                            Desription = "Boisko do piłki nożnej",
                            PitchTypeId = 1
                        },
                        new
                        {
                            PitchId = 3,
                            ActiveFlag = true,
                            Desription = "Boisko do koszykówki",
                            PitchTypeId = 3
                        },
                        new
                        {
                            PitchId = 4,
                            ActiveFlag = true,
                            Desription = "Boisko do koszykówki",
                            PitchTypeId = 3
                        },
                        new
                        {
                            PitchId = 5,
                            ActiveFlag = true,
                            Desription = "Boisko do koszykówki",
                            PitchTypeId = 3
                        },
                        new
                        {
                            PitchId = 6,
                            ActiveFlag = true,
                            Desription = "Boisko do siatkówki",
                            PitchTypeId = 4
                        },
                        new
                        {
                            PitchId = 7,
                            ActiveFlag = true,
                            Desription = "Boisko do siatkówki",
                            PitchTypeId = 4
                        },
                        new
                        {
                            PitchId = 8,
                            ActiveFlag = true,
                            Desription = "Boisko do siatkówki",
                            PitchTypeId = 4
                        },
                        new
                        {
                            PitchId = 9,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        },
                        new
                        {
                            PitchId = 10,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        },
                        new
                        {
                            PitchId = 11,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        },
                        new
                        {
                            PitchId = 12,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        },
                        new
                        {
                            PitchId = 13,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        },
                        new
                        {
                            PitchId = 14,
                            ActiveFlag = true,
                            Desription = "Kort tenisowy",
                            PitchTypeId = 2
                        });
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
                        .HasColumnName("PITCH_TYPE_NAME");

                    b.Property<decimal>("PitchTypePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PITCH_TYPE_PRICE");

                    b.HasKey("PitchTypeId");

                    b.ToTable("PITCH_TYPES", (string)null);

                    b.HasData(
                        new
                        {
                            PitchTypeId = 1,
                            PitchTypeName = "Boisko piłkarskie",
                            PitchTypePrice = 120m
                        },
                        new
                        {
                            PitchTypeId = 2,
                            PitchTypeName = "Boisko do koszykówki",
                            PitchTypePrice = 80m
                        },
                        new
                        {
                            PitchTypeId = 3,
                            PitchTypeName = "Boisko do siatkówki",
                            PitchTypePrice = 80m
                        },
                        new
                        {
                            PitchTypeId = 4,
                            PitchTypeName = "Kort tenisowy",
                            PitchTypePrice = 50m
                        });
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PitchTypeEquipment", b =>
                {
                    b.Property<int>("PitchTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PITCH_TYPE_ID");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasColumnName("EQUIPMENT_ID");

                    b.HasKey("PitchTypeId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("PITCH_TYPE_EQUIPMENT", (string)null);
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

                    b.Property<decimal>("ReservationPrice")
                        .HasColumnType("decimal(18,2)")
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

            modelBuilder.Entity("SWZOS_Database.Entities.ReservationEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RESERVATION_EQUIPMENT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasColumnName("EQUIPMENT_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("RESERVATION_ID");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ReservationId");

                    b.ToTable("RESERVATIONS_EQUIPMENT", (string)null);
                });

            modelBuilder.Entity("SWZOS_Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit")
                        .HasColumnName("ACTIVE_FLAG");

                    b.Property<bool>("DeletedFlag")
                        .HasColumnType("bit")
                        .HasColumnName("DELETED_FLAG");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("LOGIN");

                    b.Property<string>("MailAddress")
                        .IsRequired()
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

            modelBuilder.Entity("SWZOS_Database.Entities.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnName("PERMISSION_ID");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("USER_PERMISSIONS", (string)null);
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("SWZOS_Database.Entities.BlackList", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.BlackListStatus", "BlackListStatus")
                        .WithMany("BlackLists")
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
                        .WithOne("Payment")
                        .HasForeignKey("SWZOS_Database.Entities.Payment", "ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentStatus");

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

            modelBuilder.Entity("SWZOS_Database.Entities.PitchTypeEquipment", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.Equipment", "Equipment")
                        .WithMany("PitchTypeEquipment")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.PitchType", "PitchType")
                        .WithMany("PitchTypeEquipment")
                        .HasForeignKey("PitchTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

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

            modelBuilder.Entity("SWZOS_Database.Entities.ReservationEquipment", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.Equipment", "Equipment")
                        .WithMany("ReservationsEquipment")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.Reservation", "Reservation")
                        .WithMany("ReservationsEquipment")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Reservation");
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

            modelBuilder.Entity("SWZOS_Database.Entities.UserPermission", b =>
                {
                    b.HasOne("SWZOS_Database.Entities.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWZOS_Database.Entities.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.BlackListStatus", b =>
                {
                    b.Navigation("BlackLists");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Equipment", b =>
                {
                    b.Navigation("PitchTypeEquipment");

                    b.Navigation("ReservationsEquipment");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Permission", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Pitch", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.PitchType", b =>
                {
                    b.Navigation("PitchTypeEquipment");

                    b.Navigation("Pitches");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.Reservation", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("ReservationsEquipment");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.User", b =>
                {
                    b.Navigation("BlackList");

                    b.Navigation("Reservations");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("SWZOS_Database.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
