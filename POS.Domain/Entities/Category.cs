using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[PrimaryKey("Code", "Profile")]
[Table("Category")]
public partial class Category
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

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

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;

    [ForeignKey("Profile")]
    [InverseProperty("Categories")]
    public virtual Profile ProfileNavigation { get; set; } = null!;
}
