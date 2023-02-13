using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject_v1.Models;

public partial class RohanGameContext : DbContext
{
    public RohanGameContext()
    {
    }

    public RohanGameContext(DbContextOptions<RohanGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tcharacter> Tcharacters { get; set; }

    public virtual DbSet<TcharacterLogin> TcharacterLogins { get; set; }

    public virtual DbSet<TeventItem> TeventItems { get; set; }

    public virtual DbSet<Titem> Titems { get; set; }

    public virtual DbSet<Tnguild> Tnguilds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<Tcharacter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TCharact__3213E83F41D8BC2C");

            entity.ToTable("TCharacter", tb => tb.HasTrigger("GuildBuffs"));

            entity.HasIndex(e => e.UserId, "IX_TCharacter_user_id").HasFillFactor(80);

            entity.HasIndex(e => e.WorldId, "IX_Tcharacter_world_id").HasFillFactor(80);

            entity.HasIndex(e => e.Name, "UQ__TCharact__72E12F1B44B528D7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CfaceId).HasColumnName("cface_id");
            entity.Property(e => e.ChairId).HasColumnName("chair_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CstyleIndex).HasColumnName("cstyle_index");
            entity.Property(e => e.CstyleType).HasColumnName("cstyle_type");
            entity.Property(e => e.CtypeId).HasColumnName("ctype_id");
            entity.Property(e => e.Flag).HasColumnName("flag");
            entity.Property(e => e.Mode).HasColumnName("mode");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.QuickslotVersion).HasColumnName("quickslot_version");
            entity.Property(e => e.RewardTime).HasColumnName("reward_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorldId).HasColumnName("world_id");
        });

        modelBuilder.Entity<TcharacterLogin>(entity =>
        {
            entity.HasKey(e => e.CharId).HasName("PK__TCharact__2D4B23394E3E9311");

            entity.ToTable("TCharacterLogin");

            entity.HasIndex(e => e.CharId, "IX_TCharacterLogin")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CharId)
                .ValueGeneratedNever()
                .HasColumnName("char_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.LastDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_date");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.PlaySec).HasColumnName("play_sec");

            entity.HasOne(d => d.Char).WithOne(p => p.TcharacterLogin)
                .HasForeignKey<TcharacterLogin>(d => d.CharId)
                .HasConstraintName("FK__TCharacte__char___69B1A35C");
        });

        modelBuilder.Entity<TeventItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TEventIt__3213E83F6521F869");

            entity.ToTable("TEventItem");

            entity.HasIndex(e => e.CharId, "IX_TEventItem").HasFillFactor(80);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attr)
                .HasMaxLength(50)
                .HasColumnName("attr");
            entity.Property(e => e.CharId).HasColumnName("char_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EquipDexterity).HasColumnName("equip_dexterity");
            entity.Property(e => e.EquipIntelligence).HasColumnName("equip_intelligence");
            entity.Property(e => e.EquipLevel).HasColumnName("equip_level");
            entity.Property(e => e.EquipStrength).HasColumnName("equip_strength");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Stack)
                .HasDefaultValueSql("((1))")
                .HasColumnName("stack");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Titem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TItem__3213E83F049AA3C2");

            entity.ToTable("TItem");

            entity.HasIndex(e => e.CharId, "IX_TItem").HasFillFactor(80);

            entity.HasIndex(e => e.UserId, "IX_TItem_1").HasFillFactor(80);

            entity.HasIndex(e => e.Inventory, "IX_TItem_2").HasFillFactor(80);

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Attr)
                .HasMaxLength(50)
                .HasColumnName("attr");
            entity.Property(e => e.CharId).HasColumnName("char_id");
            entity.Property(e => e.ConsignDate)
                .HasDefaultValueSql("((0))")
                .HasColumnType("smalldatetime")
                .HasColumnName("consign_date");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("date");
            entity.Property(e => e.EquipDexterity).HasColumnName("equip_dexterity");
            entity.Property(e => e.EquipIntelligence).HasColumnName("equip_intelligence");
            entity.Property(e => e.EquipLevel).HasColumnName("equip_level");
            entity.Property(e => e.EquipStrength).HasColumnName("equip_strength");
            entity.Property(e => e.Inventory)
                .HasDefaultValueSql("((255))")
                .HasColumnName("inventory");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Slot)
                .HasDefaultValueSql("((255))")
                .HasColumnName("slot");
            entity.Property(e => e.Stack)
                .HasDefaultValueSql("((1))")
                .HasColumnName("stack");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Tnguild>(entity =>
        {
            entity.HasKey(e => e.MasterId).HasName("PK__TNGuild__DD5572461B7E091A");

            entity.ToTable("TNGuild");

            entity.Property(e => e.MasterId)
                .ValueGeneratedNever()
                .HasColumnName("master_id");
            entity.Property(e => e.AllianceId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("alliance_id");
            entity.Property(e => e.BuySkillPoint)
                .HasDefaultValueSql("((0))")
                .HasColumnName("buy_skill_point");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("create_date");
            entity.Property(e => e.GuildSlogan)
                .HasMaxLength(50)
                .HasDefaultValueSql("(0x00)")
                .HasColumnName("guild_slogan");
            entity.Property(e => e.MaxMasterRank)
                .HasDefaultValueSql("((1))")
                .HasColumnName("max_master_rank");
            entity.Property(e => e.Money).HasColumnName("money");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Notice)
                .HasMaxLength(400)
                .HasDefaultValueSql("(0x00)")
                .HasColumnName("notice");
            entity.Property(e => e.PassModiDate).HasColumnType("datetime");
            entity.Property(e => e.PassWd)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Postbox)
                .HasMaxLength(400)
                .HasDefaultValueSql("(0x00)")
                .HasColumnName("postbox");
            entity.Property(e => e.TaxRate).HasColumnName("tax_rate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
