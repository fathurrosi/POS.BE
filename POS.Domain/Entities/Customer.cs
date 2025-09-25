using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[PrimaryKey("Code", "Profile")]
[Table("Customer")]
public partial class Customer
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;

    [ForeignKey("Profile")]
    [InverseProperty("Customers")]
    public virtual Profile ProfileNavigation { get; set; } = null!;
}
