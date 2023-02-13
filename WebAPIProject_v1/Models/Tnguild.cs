using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class Tnguild
{
    public int MasterId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public byte[] Notice { get; set; } = null!;

    public byte[] Postbox { get; set; } = null!;

    public long Money { get; set; }

    public int Point { get; set; }

    public byte MaxMasterRank { get; set; }

    public byte TaxRate { get; set; }

    public int? AllianceId { get; set; }

    public byte[] GuildSlogan { get; set; } = null!;

    public string? PassWd { get; set; }

    public DateTime? PassModiDate { get; set; }

    public byte? BuySkillPoint { get; set; }
}
