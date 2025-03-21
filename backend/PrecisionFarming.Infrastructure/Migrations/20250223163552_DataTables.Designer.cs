﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using PrecisionFarming.Infrastructure.DbContext;

#nullable disable

namespace PrecisionFarming.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250223163552_DataTables")]
    partial class DataTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Crop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Crops");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e3a5f05-5c67-4a77-afaa-c1449eeb6693"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4729),
                            Name = "Alfalfa"
                        },
                        new
                        {
                            Id = new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4897),
                            Name = "Barley"
                        },
                        new
                        {
                            Id = new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4918),
                            Name = "Canola"
                        },
                        new
                        {
                            Id = new Guid("f25a2358-8b43-4a16-8379-8b0313179ec9"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4934),
                            Name = "Corn"
                        },
                        new
                        {
                            Id = new Guid("a936c5d8-2dd2-41e7-b071-68b78c5a48d0"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4951),
                            Name = "Fababean"
                        },
                        new
                        {
                            Id = new Guid("a31b7081-ca69-4548-a614-c9afa1ea0197"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4970),
                            Name = "Oats"
                        },
                        new
                        {
                            Id = new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(4987),
                            Name = "Peas"
                        },
                        new
                        {
                            Id = new Guid("c7961535-9d7b-433d-9f4f-a458c7c6a3b6"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5002),
                            Name = "Soybeans"
                        },
                        new
                        {
                            Id = new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(5021),
                            Name = "Wheat"
                        });
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.CropVariety", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CropId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distributor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CropId");

                    b.ToTable("CropVarieties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1337a54-fdde-4e50-aca3-6f682a8c497f"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6258),
                            CropId = new Guid("2db4ee88-2bed-4e64-a95d-0cf667f67370"),
                            Description = "Very high yield potential. Shorter than CDC Austenson with strong straw and excellent standability. Higher test weight and increased plumpness.",
                            Distributor = "CANTERRA SEEDS LTD",
                            Name = "AAC Lariat Feed 2-Row"
                        },
                        new
                        {
                            Id = new Guid("29d51eb2-6de5-49e1-8d8b-4bf87cd6a582"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6351),
                            CropId = new Guid("f29bf920-7509-4fef-84cf-5c0f35617035"),
                            Description = "Introducing InVigor L330PC an early maturing hybrid with excellent yield potential and strong standability. Coupled with our patented Pod Shatter Reduction technology, first generation clubroot resistance, strong standability, and the yield potential to exceed InVigor L233P all give InVigor L330PC potential across all growing zones.",
                            Distributor = "BASF/Invigor",
                            Name = "InVigor L330PC Hybrid"
                        },
                        new
                        {
                            Id = new Guid("1297b0be-a6ef-4670-a9b1-bec0007e9ab0"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6405),
                            CropId = new Guid("70916e69-1003-4efb-ac4e-5263dd3ff0c7"),
                            Description = "High yield potential with earlier maturity. Very high protein content",
                            Distributor = "CANTERRA SEEDS",
                            Name = "CS ProStar Yellow"
                        },
                        new
                        {
                            Id = new Guid("09bdf5e3-040c-4e8e-abc4-e47a2e418d08"),
                            CreatedAt = new DateTime(2025, 2, 23, 16, 35, 52, 13, DateTimeKind.Utc).AddTicks(6445),
                            CropId = new Guid("ca2e08ef-05c4-4855-a3a6-ee40e0ad77ff"),
                            Description = "Very high yields. Midge tolerance",
                            Distributor = "Nutrien Ag Solutions",
                            Name = "AAC Camrose VB"
                        });
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Area")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Polygon>("Boundary")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.FieldCrop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CropVarietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SowingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Yield")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CropVarietyId");

                    b.HasIndex("FieldId");

                    b.ToTable("FieldsCrops");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f355d1f0-2c69-4cbb-adb6-ff31c8833972"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("53728ad8-bda9-419c-95da-f844eaf21e87"),
                            Name = "Farmer",
                            NormalizedName = "FARMER"
                        },
                        new
                        {
                            Id = new Guid("f788b7ff-bd81-46d9-af7c-b1acfb98a527"),
                            Name = "Agronomist",
                            NormalizedName = "AGRONOMIST"
                        });
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.CropVariety", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Crop", "Crop")
                        .WithMany("Varieties")
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Field", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.Farm", "Farm")
                        .WithMany("Fields")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.FieldCrop", b =>
                {
                    b.HasOne("PrecisionFarming.Domain.Entities.CropVariety", "Variety")
                        .WithMany()
                        .HasForeignKey("CropVarietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrecisionFarming.Domain.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Variety");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Crop", b =>
                {
                    b.Navigation("Varieties");
                });

            modelBuilder.Entity("PrecisionFarming.Domain.Entities.Farm", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
