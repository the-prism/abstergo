﻿// <auto-generated />
using System;
using Abstergo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Abstergo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220722234835_InitalDB")]
    partial class InitalDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Abstergo.Data.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFolder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Abstergo.Data.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FavoriteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteId");

                    b.ToTable("FavoriteLinks");
                });

            modelBuilder.Entity("Abstergo.Data.Link", b =>
                {
                    b.HasOne("Abstergo.Data.Favorite", "Favorite")
                        .WithMany("Links")
                        .HasForeignKey("FavoriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Favorite");
                });

            modelBuilder.Entity("Abstergo.Data.Favorite", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}