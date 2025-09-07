﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Keyless]
public partial class VUserPrevillage
{
    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Role { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Menu { get; set; }

    [Column("MenuID")]
    public int MenuId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    public bool? AllowCreate { get; set; }

    public bool? AllowRead { get; set; }

    public bool? AllowUpdate { get; set; }

    public bool? AllowDelete { get; set; }

    public bool? AllowPrint { get; set; }
}
