﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programs_Downloader_Bot.Data;

namespace Programs_Downloader_Bot.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20221029181743_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30");

            modelBuilder.Entity("Programs_Downloader_Bot.Models.InstallableProgram", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DownloadLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProgramName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InstallablePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
