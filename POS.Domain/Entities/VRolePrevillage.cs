using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Keyless]
public partial class VRolePrevillage
{
    [StringLength(100)]
    [Unicode(false)]
    public string? Profile { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Role { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MenuCode { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? MenuName { get; set; }

    [Column("MenuID")]
    public int MenuId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    public bool? AllowCreate { get; set; }

    public bool? AllowRead { get; set; }

    public bool? AllowUpdate { get; set; }

    public bool? AllowDelete { get; set; }

    public bool? AllowPrint { get; set; }

    [Column("MenuParentID")]
    public int? MenuParentId { get; set; }

    public int? MenuSequence { get; set; }
}
