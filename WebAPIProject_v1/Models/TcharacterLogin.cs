using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class TcharacterLogin
{
    public int CharId { get; set; }

    public int Count { get; set; }

    public DateTime LastDate { get; set; }

    public int PlaySec { get; set; }

    public byte Login { get; set; }

    public virtual Tcharacter Char { get; set; } = null!;
}
