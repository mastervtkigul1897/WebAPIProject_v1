using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class TeventItem
{
    public int Id { get; set; }

    public int Type { get; set; }

    public byte[] Attr { get; set; } = null!;

    public byte Stack { get; set; }

    public byte Rank { get; set; }

    public byte EquipLevel { get; set; }

    public short EquipStrength { get; set; }

    public short EquipDexterity { get; set; }

    public short EquipIntelligence { get; set; }

    public int CharId { get; set; }

    public DateTime Date { get; set; }
}
