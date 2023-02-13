using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject_v1.Models;

public partial class RohanUserContext : DbContext
{
    public RohanUserContext()
    {
    }

    public RohanUserContext(DbContextOptions<RohanUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tuser> Tusers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<Tuser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TUser__B9BE370F4B422AD5");

            entity.ToTable("TUser");

            entity.HasIndex(e => e.LoginId, "IX_TUser")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BillNo).HasColumnName("bill_no");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.LoginId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("login_id");
            entity.Property(e => e.LoginPw)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login_pw");
            entity.Property(e => e.OptionkeyInfo)
                .HasMaxLength(24)
                .HasDefaultValueSql("(0x00)")
                .HasColumnName("optionkey_info");
            entity.Property(e => e.OptionkeyVersion).HasColumnName("optionkey_version");
            entity.Property(e => e.Points)
                .HasDefaultValueSql("((0))")
                .HasColumnName("points");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.SessionDate)
                .HasDefaultValueSql("((0))")
                .HasColumnType("datetime")
                .HasColumnName("session_date");
            entity.Property(e => e.SessionId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasDefaultValueSql("('0')")
                .IsFixedLength()
                .HasColumnName("session_id");
            entity.Property(e => e.Species).HasColumnName("species");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
