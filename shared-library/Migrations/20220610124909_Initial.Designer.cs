﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shared_library.Contexts;

#nullable disable

namespace shared_library.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220610124909_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("shared_library.Servers.ContactAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postal_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street_2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("contactAddresses");
                });

            modelBuilder.Entity("shared_library.Servers.ContactInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("addressid")
                        .HasColumnType("int");

                    b.Property<string>("business_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("addressid");

                    b.ToTable("contactInfos");
                });

            modelBuilder.Entity("shared_library.Servers.MarketPlace", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bad_attributes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("five_star_ratings_average")
                        .HasColumnType("real");

                    b.Property<float?>("five_star_total_rating_count_by_role")
                        .HasColumnType("real");

                    b.Property<string>("good_attributes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marketplace_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("min_ratings_required_to_be_public")
                        .HasColumnType("real");

                    b.Property<bool>("rating_private")
                        .HasColumnType("bit");

                    b.Property<int?>("total_items")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("marketPlaces");
                });

            modelBuilder.Entity("shared_library.Servers.ScrapedUser", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("contact_infoid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_added")
                        .HasColumnType("datetime2");

                    b.Property<int?>("marketlaceid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("contact_infoid");

                    b.HasIndex("marketlaceid");

                    b.ToTable("scrapedUsers");
                });

            modelBuilder.Entity("shared_library.Servers.ContactInfo", b =>
                {
                    b.HasOne("shared_library.Servers.ContactAddress", "address")
                        .WithMany()
                        .HasForeignKey("addressid");

                    b.Navigation("address");
                });

            modelBuilder.Entity("shared_library.Servers.ScrapedUser", b =>
                {
                    b.HasOne("shared_library.Servers.ContactInfo", "contact_info")
                        .WithMany()
                        .HasForeignKey("contact_infoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shared_library.Servers.MarketPlace", "marketlace")
                        .WithMany()
                        .HasForeignKey("marketlaceid");

                    b.Navigation("contact_info");

                    b.Navigation("marketlace");
                });
#pragma warning restore 612, 618
        }
    }
}
