using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("UserId", Name = "IX_Categories_UserId")]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UserId { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [InverseProperty("Category")]
    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    [ForeignKey("UserId")]
    [InverseProperty("Categories")]
    public virtual AspNetUser? User { get; set; }
}
