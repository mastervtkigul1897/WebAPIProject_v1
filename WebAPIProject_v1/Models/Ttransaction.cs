using System;
using System.Collections.Generic;

namespace WebAPIProject_v1.Models;

public partial class Ttransaction
{
    public int Id { get; set; }

    public string? LoginId { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public double? Price { get; set; }

    public string? Reference { get; set; }

    public string? Point { get; set; }

    public string? Status { get; set; }

    public string? SellerId { get; set; }

    public string? Date { get; set; }
}
