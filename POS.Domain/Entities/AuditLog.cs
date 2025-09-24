using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Table("AuditLog")]
public partial class AuditLog
{
    [Key]
    [Column("LogID")]
    public long LogId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LogTimestamp { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LogLevel { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ActionType { get; set; } = null!;

    [StringLength(255)]
    public string LogMessage { get; set; } = null!;

    public string? ActionDetails { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Terminal { get; set; }
}
