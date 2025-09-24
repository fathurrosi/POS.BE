using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Keyless]
[Table("ProductStockHistory")]
public partial class ProductStockHistory
{
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Stock { get; set; }

    public DateOnly? StockDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
