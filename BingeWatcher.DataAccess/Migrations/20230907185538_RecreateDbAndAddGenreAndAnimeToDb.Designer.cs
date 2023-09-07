﻿// <auto-generated />
using BingeWatcher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BingeWatcher.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230907185538_RecreateDbAndAddGenreAndAnimeToDb")]
    partial class RecreateDbAndAddGenreAndAnimeToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.7.23375.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BingeWatcher.Models.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("End_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Main_Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_Of_Episodes")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Animes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            Main_Picture = "mainpic1.jpg",
                            Number_Of_Episodes = 1,
                            Rating = "G",
                            Status = "finished",
                            Title = "Anime 1"
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 1,
                            Main_Picture = "mainpic2.jpg",
                            Number_Of_Episodes = 1,
                            Rating = "G",
                            Status = "finished",
                            Title = "Anime 2"
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 1,
                            Main_Picture = "mainpic3.jpg",
                            Number_Of_Episodes = 1,
                            Rating = "G",
                            Status = "finished",
                            Title = "Anime 3"
                        });
                });

            modelBuilder.Entity("BingeWatcher.Models.AnimeGenres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnimeGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimeId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            Id = 2,
                            AnimeId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            Id = 3,
                            AnimeId = 2,
                            GenreId = 3
                        });
                });

            modelBuilder.Entity("BingeWatcher.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Terror"
                        });
                });

            modelBuilder.Entity("BingeWatcher.Models.Anime", b =>
                {
                    b.HasOne("BingeWatcher.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}