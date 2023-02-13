using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class Tcharacter
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int CtypeId { get; set; }

    public int CfaceId { get; set; }

    public int ChairId { get; set; }

    public int UserId { get; set; }

    public byte Mode { get; set; }

    public DateTime CreateDate { get; set; }

    public byte Flag { get; set; }

    public byte CstyleType { get; set; }

    public byte CstyleIndex { get; set; }

    public byte WorldId { get; set; }

    public short QuickslotVersion { get; set; }

    public int RewardTime { get; set; }

    public virtual TcharacterLogin? TcharacterLogin { get; set; }
}
