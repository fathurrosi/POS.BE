using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities;

[Table("Profile")]
public partial class Profile
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(5000)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Subtitle { get; set; }

    [StringLength(5000)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Website { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Logo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LogoExtension { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    [InverseProperty("ProfileNavigation")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
