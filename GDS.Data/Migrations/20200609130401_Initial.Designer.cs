﻿// <auto-generated />
using System;
using GDS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GDS.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200609130401_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GDS.Core.Models.Bible", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfBooks")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("Bibles");
                });

            modelBuilder.Entity("GDS.Core.Models.BibleBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BookCode")
                        .HasColumnType("int");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BibleId");

                    b.HasIndex("BookCode");

                    b.HasIndex("BookId");

                    b.HasIndex("LocalId")
                        .IsUnique();

                    b.HasIndex("Version");

                    b.ToTable("BibleBooks");
                });

            modelBuilder.Entity("GDS.Core.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("NTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Section")
                        .HasColumnType("int");

                    b.Property<string>("ShortTitle")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("ShortTitle");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("GDS.Core.Models.Heading", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Chapter");

                    b.HasIndex("Position");

                    b.ToTable("Headings");
                });

            modelBuilder.Entity("GDS.Core.Models.Verse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BibleBookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ChapterNum")
                        .HasColumnType("int");

                    b.Property<Guid?>("HeadingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BibleBookId");

                    b.HasIndex("ChapterNum");

                    b.HasIndex("HeadingId");

                    b.HasIndex("LocalId")
                        .IsUnique();

                    b.HasIndex("Position");

                    b.ToTable("Verses");
                });

            modelBuilder.Entity("GDS.Core.Models.BibleBook", b =>
                {
                    b.HasOne("GDS.Core.Models.Bible", "Bible")
                        .WithMany("BibleBooks")
                        .HasForeignKey("BibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GDS.Core.Models.Book", "Book")
                        .WithMany("BibleBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GDS.Core.Models.Verse", b =>
                {
                    b.HasOne("GDS.Core.Models.BibleBook", "BibleBook")
                        .WithMany("Verses")
                        .HasForeignKey("BibleBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GDS.Core.Models.Heading", null)
                        .WithMany("Verses")
                        .HasForeignKey("HeadingId");
                });
#pragma warning restore 612, 618
        }
    }
}