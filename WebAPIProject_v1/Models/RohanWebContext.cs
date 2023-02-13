using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject_v1.Models;

public partial class RohanWebContext : DbContext
{
    public RohanWebContext()
    {
    }

    public RohanWebContext(DbContextOptions<RohanWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tproduct> Tproducts { get; set; }

    public virtual DbSet<Ttransaction> Ttransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tproduct>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("PK_TItems");

            entity.ToTable("TProducts");

            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Itemname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("itemname");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Ttransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_THistory");

            entity.ToTable("TTransactions");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.LoginId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login_id");
            entity.Property(e => e.Point)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("point");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.SellerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seller_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
