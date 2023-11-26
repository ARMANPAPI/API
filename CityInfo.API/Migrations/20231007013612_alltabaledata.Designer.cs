﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoDbContext))]
    [Migration("20231007013612_alltabaledata")]
    partial class alltabaledata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CityInfo.API.Entiteis.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "SHAHRESTAN",
                            Name = "Lorstan"
                        },
                        new
                        {
                            Id = 2,
                            Description = "shemirn",
                            Name = "Tehran"
                        },
                        new
                        {
                            Id = 3,
                            Description = "33poleh",
                            Name = "esfahan"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entiteis.PointOfInterset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterset");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "sarsabsz",
                            Name = "BISHE"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "test2",
                            Name = "test2"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "test3",
                            Name = "test3"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "test4",
                            Name = "test4"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "test5",
                            Name = "test5"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entiteis.PointOfInterset", b =>
                {
                    b.HasOne("CityInfo.API.Entiteis.City", "City")
                        .WithMany("pointOfInterset")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entiteis.City", b =>
                {
                    b.Navigation("pointOfInterset");
                });
#pragma warning restore 612, 618
        }
    }
}
