using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("UserId", Name = "IX_WishLists_UserId")]
public partial class WishList
{
    [Key]
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public string? Photo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("WishLists")]
    public virtual AspNetUser? User { get; set; }
}
