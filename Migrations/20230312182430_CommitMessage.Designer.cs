﻿// <auto-generated />
using System;
using Golf_Club_Management.dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Golf_Club_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230312182430_CommitMessage")]
    partial class CommitMessage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Golf_Club_Management.Models.Golfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Handicap")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("golfers");
                });

            modelBuilder.Entity("Golf_Club_Management.Models.TeeTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerFourId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerOneId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerThreeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerTwoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("teeTimes");
                });
#pragma warning restore 612, 618
        }
    }
}