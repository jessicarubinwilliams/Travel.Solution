﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Models;

namespace Travel.Migrations
{
    [DbContext(typeof(TravelContext))]
    [Migration("20211117030133_AddJoinEntity")]
    partial class AddJoinEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Travel.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85) CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("varchar(56) CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Travel.Models.DestinationReview", b =>
                {
                    b.Property<int>("DestinationReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("DestinationReviewId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("ReviewId");

                    b.ToTable("DestinationReview");
                });

            modelBuilder.Entity("Travel.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VisitDate")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85) CHARACTER SET utf8mb4");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Travel.Models.DestinationReview", b =>
                {
                    b.HasOne("Travel.Models.Destination", "Destination")
                        .WithMany("DestinationReviewJoinEntity")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel.Models.Review", "Review")
                        .WithMany("DestinationReviewJoinEntity")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Travel.Models.Destination", b =>
                {
                    b.Navigation("DestinationReviewJoinEntity");
                });

            modelBuilder.Entity("Travel.Models.Review", b =>
                {
                    b.Navigation("DestinationReviewJoinEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
