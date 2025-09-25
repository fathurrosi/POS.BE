using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Table("Inventory")]
public partial class Inventory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Product { get; set; } = null!;

    public int Warehouse { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LastUpdated { get; set; }

    [ForeignKey("Product")]
    [InverseProperty("Inventories")]
    public virtual Product ProductNavigation { get; set; } = null!;

    [ForeignKey("Warehouse")]
    [InverseProperty("Inventories")]
    public virtual Warehouse WarehouseNavigation { get; set; } = null!;
}
