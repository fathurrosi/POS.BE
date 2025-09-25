using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Table("Product")]
public partial class Product
{
    [StringLength(50)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Type { get; set; }

    public int? Category { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string UniqueCode { get; set; } = null!;

    public int? Stock { get; set; }

    public int? MinStock { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? BasePrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SalesPrice { get; set; }

    [InverseProperty("ProductNavigation")]
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    [ForeignKey("Profile")]
    [InverseProperty("Products")]
    public virtual Profile ProfileNavigation { get; set; } = null!;
}
