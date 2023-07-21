﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheRealManSys.Data;

#nullable disable

namespace TheRealManSys.Migrations.ManSysRequest
{
    [DbContext(typeof(ManSysRequestContext))]
    partial class ManSysRequestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TheRealManSys.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReplyId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ReplyId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestComments");
                });

            modelBuilder.Entity("TheRealManSys.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("TheRealManSys.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Store")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VendorId");

                    b.ToTable("RequestItems");
                });

            modelBuilder.Entity("TheRealManSys.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeliveryDateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeliveryDateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeliveryId")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ManagerId")
                        .HasColumnType("text");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("TheRealManSys.Models.Requests.Draft", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("drafts");
                });

            modelBuilder.Entity("TheRealManSys.Models.Requests.DraftItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<string>("CountType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("draftId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("draftId");

                    b.ToTable("draftItems");
                });

            modelBuilder.Entity("TheRealManSys.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Argb")
                        .HasColumnType("integer");

                    b.Property<int>("GlobalStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDefaultOnCreateItem")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestStatuses");
                });

            modelBuilder.Entity("TheRealManSys.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TheRealManSys.Models.Comment", b =>
                {
                    b.HasOne("TheRealManSys.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealManSys.Models.User", "Reply")
                        .WithMany()
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealManSys.Models.Request", "Request")
                        .WithMany("Comments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Reply");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("TheRealManSys.Models.Item", b =>
                {
                    b.HasOne("TheRealManSys.Models.Request", "Request")
                        .WithMany("Items")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealManSys.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("TheRealManSys.Models.Contact", "VendorContacts")
                        .WithMany()
                        .HasForeignKey("VendorId");

                    b.Navigation("Request");

                    b.Navigation("Status");

                    b.Navigation("VendorContacts");
                });

            modelBuilder.Entity("TheRealManSys.Models.Request", b =>
                {
                    b.HasOne("TheRealManSys.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheRealManSys.Models.User", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId");

                    b.HasOne("TheRealManSys.Models.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("TheRealManSys.Models.Status", "GeneralStatus")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Creator");

                    b.Navigation("Delivery");

                    b.Navigation("GeneralStatus");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("TheRealManSys.Models.Requests.Draft", b =>
                {
                    b.HasOne("TheRealManSys.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheRealManSys.Models.Requests.DraftItem", b =>
                {
                    b.HasOne("TheRealManSys.Models.Requests.Draft", "draft")
                        .WithMany()
                        .HasForeignKey("draftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("draft");
                });

            modelBuilder.Entity("TheRealManSys.Models.Request", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
