using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[PrimaryKey("ProductCode", "Profile")]
[Table("ProductPrice")]
public partial class ProductPrice
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? BuyPricePerunit { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SellPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PriceDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SupplierCode { get; set; }

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;
}
