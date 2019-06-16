﻿// <auto-generated />
using System;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190609090149_AddTblContact")]
    partial class AddTblContact
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Model.Tables.Tbl_City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Country_FG");

                    b.Property<string>("Image");

                    b.Property<bool>("ShowInSlider");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Country_FG");

                    b.ToTable("tbl_Cities");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("tbl_Contacts");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("tbl_Countries");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsSpecific");

                    b.Property<string>("PathWays");

                    b.Property<int>("Percent");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("tbl_Discounts");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Factore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdultCount");

                    b.Property<int>("BabyCount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PathwayId_FG");

                    b.Property<decimal>("SumPrice");

                    b.Property<string>("Time");

                    b.Property<string>("UseDisCount");

                    b.Property<string>("UserId_FG");

                    b.Property<bool>("isPayed");

                    b.HasKey("Id");

                    b.HasIndex("PathwayId_FG");

                    b.HasIndex("UserId_FG");

                    b.ToTable("tbl_Factores");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_NewsLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("tbl_NewsLetters");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_PathWay", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<int>("Capacity");

                    b.Property<int>("Destination_FG");

                    b.Property<decimal>("PriceForAdultDollar");

                    b.Property<decimal>("PriceForAdultUro");

                    b.Property<decimal>("PriceForBabyDollar");

                    b.Property<decimal>("PriceForBabyUro");

                    b.Property<int>("Source_FG");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.HasKey("id");

                    b.ToTable("tbl_PathWays");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Reserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adult");

                    b.Property<string>("AgentId");

                    b.Property<int>("Baby");

                    b.Property<string>("Fullname")
                        .IsRequired();

                    b.Property<int>("PathId");

                    b.Property<DateTime>("ReservedDate");

                    b.Property<string>("Status");

                    b.Property<int>("SumCount");

                    b.Property<decimal>("SumPrice");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("PathId");

                    b.ToTable("Tbl_Reserve");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Setting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutImag1");

                    b.Property<string>("AboutImag2");

                    b.Property<string>("Address");

                    b.Property<string>("ContactUs");

                    b.Property<string>("CopyRight");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("EmailPwd");

                    b.Property<string>("Logo");

                    b.Property<string>("PageNumber")
                        .IsRequired();

                    b.Property<string>("PanelLogo");

                    b.Property<string>("Phone");

                    b.Property<string>("Slogan");

                    b.Property<string>("Smpt");

                    b.Property<string>("SmsApiService");

                    b.Property<string>("SmsNumber");

                    b.Property<string>("SmsSecretKey");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("facebook");

                    b.Property<string>("instagrm");

                    b.Property<string>("linkedin");

                    b.Property<string>("twitter");

                    b.HasKey("ID");

                    b.ToTable("Tbl_Settings");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Users", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Mobile");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Sex");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Weblog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Authore");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("KeyWords")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("UserId_Fk");

                    b.Property<string>("image");

                    b.Property<bool>("isnews");

                    b.HasKey("id");

                    b.HasIndex("UserId_Fk");

                    b.ToTable("tbl_Weblogs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_City", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Country", "Tbl_Country")
                        .WithMany("tbl_Cities")
                        .HasForeignKey("Country_FG")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Factore", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_PathWay", "Tbl_PathWay")
                        .WithMany("tbl_Factores")
                        .HasForeignKey("PathwayId_FG")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Model.Tables.Tbl_Users", "Tbl_User")
                        .WithMany("Tbl_Factores")
                        .HasForeignKey("UserId_FG");
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Reserve", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Users", "Tbl_Users")
                        .WithMany("tbl_Reserves")
                        .HasForeignKey("AgentId");

                    b.HasOne("DAL.Model.Tables.Tbl_PathWay", "Tbl_PathWay")
                        .WithMany("tbl_Reserves")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Model.Tables.Tbl_Weblog", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Users", "Tbl_Users")
                        .WithMany()
                        .HasForeignKey("UserId_Fk");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Model.Tables.Tbl_Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Model.Tables.Tbl_Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
