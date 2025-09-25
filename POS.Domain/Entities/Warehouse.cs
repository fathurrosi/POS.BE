using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

public partial class Warehouse
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Location { get; set; } = null!;

    [InverseProperty("WarehouseNavigation")]
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
