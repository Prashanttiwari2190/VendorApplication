﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SFM.Automation.QuickbooksImport.Data.Models.Quickbooks;

namespace SFM.Automation.QuickbooksImport.Data.Migrations.EntityFramework
{
    [DbContext(typeof(TokensContext))]
    [Migration("20200310143348_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("SFM.Automation.QuickbooksImport.Data.Models.Quickbooks.Token", b =>
                {
                    b.Property<string>("RealmId")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.HasKey("RealmId");

                    b.ToTable("Token");
                });
#pragma warning restore 612, 618
        }
    }
}
