﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240212210245_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Data.Entities.BranchEntity", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BranchId");

                    b.ToTable("branches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            Title = "Firma X"
                        },
                        new
                        {
                            BranchId = 2,
                            Title = "XYZ Spółka z o.o."
                        },
                        new
                        {
                            BranchId = 3,
                            Title = "XYZ Spółka Akcyjna"
                        },
                        new
                        {
                            BranchId = 4,
                            Title = "XYZ Spółka komandytowa"
                        },
                        new
                        {
                            BranchId = 5,
                            Title = "Firma Y"
                        });
                });

            modelBuilder.Entity("Data.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfDismissal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeId");

                    b.HasIndex("BranchId");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            BranchId = 1,
                            DateOfEmployment = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ewa.maj@firmax.pl",
                            LastName = "Maj",
                            Name = "Ewa",
                            PESEL = "76051112345",
                            Phone = "500100200",
                            Position = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            BranchId = 2,
                            DateOfDismissal = new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfEmployment = new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marcin.zawadzki@xyz.com",
                            LastName = "Zawadzki",
                            Name = "Marcin",
                            PESEL = "85012223456",
                            Phone = "600200300",
                            Position = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            BranchId = 3,
                            DateOfEmployment = new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anna.kowalczyk@xyzsa.com",
                            LastName = "Kowalczyk",
                            Name = "Anna",
                            PESEL = "94021567890",
                            Phone = "700300400",
                            Position = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            BranchId = 4,
                            DateOfEmployment = new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "krzysztof.borowski@xyzsk.com",
                            LastName = "Borowski",
                            Name = "Krzysztof",
                            PESEL = "87032145698",
                            Phone = "800400500",
                            Position = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            BranchId = 5,
                            DateOfDismissal = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfEmployment = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "magdalena.sikorska@firmax.pl",
                            LastName = "Sikorska",
                            Name = "Magdalena",
                            PESEL = "88040512345",
                            Phone = "900500600",
                            Position = 5
                        },
                        new
                        {
                            EmployeeId = 6,
                            BranchId = 1,
                            DateOfEmployment = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tomasz.nowak@xyz.com",
                            LastName = "Nowak",
                            Name = "Tomasz",
                            PESEL = "92050867890",
                            Phone = "910610710",
                            Position = 1
                        },
                        new
                        {
                            EmployeeId = 7,
                            BranchId = 2,
                            DateOfEmployment = new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "julia.wojcik@xyzsa.com",
                            LastName = "Wójcik",
                            Name = "Julia",
                            PESEL = "93061178901",
                            Phone = "920720820",
                            Position = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5",
                            ConcurrencyStamp = "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "ea67219e-154f-4cd7-b4b9-017a4551f395",
                            ConcurrencyStamp = "ea67219e-154f-4cd7-b4b9-017a4551f395",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "efa14892-ce09-4c41-b787-87804119e174",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bcb27465-b834-45ec-9fb1-f55491399a94",
                            Email = "admin@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOLJ4uGK671vdiT8mV/NJ4CLrn8rOzVSqvUlD3rmuvvBVIKer8qihwc6mCyYSLqdAg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ebb21189-c9e8-404e-a408-699727c4e2d6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "be93e15f-e31a-4606-9483-0795771e6d0b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a76aa99e-c532-43a7-8279-1d13af49629a",
                            Email = "user@wsei.edu.pl",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@WSEI.EDU.PL",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEDy63vjbgZ6fjFQt/R4tsqjOv7vCj3P3bmOOT+cODXaAX7MLOD1mL62yQVIiR/r++Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7c186ae9-d67a-484f-8481-b6a2153bc41c",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "efa14892-ce09-4c41-b787-87804119e174",
                            RoleId = "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5"
                        },
                        new
                        {
                            UserId = "be93e15f-e31a-4606-9483-0795771e6d0b",
                            RoleId = "ea67219e-154f-4cd7-b4b9-017a4551f395"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.BranchEntity", b =>
                {
                    b.OwnsOne("Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("BranchEntityBranchId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BranchEntityBranchId");

                            b1.ToTable("branches");

                            b1.WithOwner()
                                .HasForeignKey("BranchEntityBranchId");

                            b1.HasData(
                                new
                                {
                                    BranchEntityBranchId = 1,
                                    City = "Kraków",
                                    Country = "Polska",
                                    Number = "123",
                                    PostalCode = "00-015",
                                    Region = "mazowieckie",
                                    Street = "Korona"
                                },
                                new
                                {
                                    BranchEntityBranchId = 2,
                                    City = "Kraków",
                                    Country = "Polska",
                                    Number = "3",
                                    PostalCode = "33-212",
                                    Region = "Małopolskie",
                                    Street = "Rynek Główny"
                                },
                                new
                                {
                                    BranchEntityBranchId = 3,
                                    City = "Warszawa",
                                    Country = "Polska",
                                    Number = "13",
                                    PostalCode = "22-143",
                                    Region = "Mazowieckie",
                                    Street = "Praska"
                                },
                                new
                                {
                                    BranchEntityBranchId = 4,
                                    City = "Poznań",
                                    Country = "Polska",
                                    Number = "15",
                                    PostalCode = "41-320",
                                    Region = "Wielkopolskie",
                                    Street = "Błotna"
                                },
                                new
                                {
                                    BranchEntityBranchId = 5,
                                    City = "Kraków",
                                    Country = "Polska",
                                    Number = "10",
                                    PostalCode = "32-040",
                                    Region = "Małopolskie",
                                    Street = "Topolowa"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("Data.Entities.BranchEntity", "Branch")
                        .WithMany("Employees")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.BranchEntity", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
