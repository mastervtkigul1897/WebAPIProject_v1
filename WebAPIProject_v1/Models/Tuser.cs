using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class Tuser
{
    public int UserId { get; set; }

    public string LoginId { get; set; } = null!;

    public string LoginPw { get; set; } = null!;

    public byte Grade { get; set; }

    public string SessionId { get; set; } = null!;

    public DateTime SessionDate { get; set; }

    public int Species { get; set; }

    public int BillNo { get; set; }

    public byte ServerId { get; set; }

    public short OptionkeyVersion { get; set; }

    public byte[] OptionkeyInfo { get; set; } = null!;

    public int? PortalId { get; set; }

    public int? Points { get; set; }
}
