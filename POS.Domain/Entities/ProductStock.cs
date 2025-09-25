using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Keyless]
[Table("ProductStock")]
public partial class ProductStock
{
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductCode { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Stock { get; set; }

    public DateOnly? StockDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    public int IsActive { get; set; }
}
