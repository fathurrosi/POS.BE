using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[PrimaryKey("Code", "Profile")]
[Table("Unit")]
public partial class Unit
{
    [Key]
    [StringLength(6)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Profile { get; set; } = null!;

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
}
