﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdaTech.EncurtadorDeLinks.WebAPI.Migrations
{
    [DbContext(typeof(EncurtadorLinksContext))]
    partial class EncurtadorLinksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AdaTech.EncurtadorDeLinks.WebAPI.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlCurta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlOriginal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
