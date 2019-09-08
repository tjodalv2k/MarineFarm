﻿// <auto-generated />
using MarineFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarineFarm.Migrations
{
    [DbContext(typeof(MarineContext))]
    [Migration("20190908155354_AddedNumberOfFishToTank")]
    partial class AddedNumberOfFishToTank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarineFarm.Models.Fish", b =>
                {
                    b.Property<int>("FishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TankId");

                    b.Property<string>("Weight");

                    b.HasKey("FishId");

                    b.ToTable("Fish");
                });

            modelBuilder.Entity("MarineFarm.Models.Movement", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FishId");

                    b.Property<int>("TankIdFrom");

                    b.Property<int>("TankIdTo");

                    b.HasKey("MovementId");

                    b.ToTable("Movement");
                });

            modelBuilder.Entity("MarineFarm.Models.Tank", b =>
                {
                    b.Property<int>("TankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("Description");

                    b.Property<int>("NumberOfFish");

                    b.HasKey("TankId");

                    b.ToTable("Tank");
                });
#pragma warning restore 612, 618
        }
    }
}
