using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[PrimaryKey("Code", "Profile")]
[Table("Supplier")]
public partial class Supplier
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CellPhone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;

    [ForeignKey("Profile")]
    [InverseProperty("Suppliers")]
    public virtual Profile ProfileNavigation { get; set; } = null!;
}
