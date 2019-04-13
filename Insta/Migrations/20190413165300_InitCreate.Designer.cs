﻿// <auto-generated />
using System;
using Insta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Insta.Migrations
{
    [DbContext(typeof(InstaWebDbContext))]
    [Migration("20190413165300_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Insta.Models.AccountInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<int>("ParsedPostCount");

                    b.Property<int>("TotalMediaCount");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("AccountInfo");
                });

            modelBuilder.Entity("Insta.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountInfoID");

                    b.Property<string>("Caption");

                    b.Property<string>("LocationCountry");

                    b.Property<int>("LocationId");

                    b.Property<string>("LocationName");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("ID");

                    b.HasIndex("AccountInfoID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Insta.Models.Post", b =>
                {
                    b.HasOne("Insta.Models.AccountInfo", "AccountInfo")
                        .WithMany("Posts")
                        .HasForeignKey("AccountInfoID");
                });
#pragma warning restore 612, 618
        }
    }
}
