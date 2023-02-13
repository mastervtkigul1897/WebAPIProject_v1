using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class Tproduct
{
    public int Itemid { get; set; }

    public string? Itemname { get; set; }

    public int? Type { get; set; }

    public int? Price { get; set; }

    public int? Qty { get; set; }

    public string? Category { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }
}
