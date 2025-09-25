using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

public partial class Transaction
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    [StringLength(50)]
    public string TransactionType { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }
}
