using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("CategoryId", Name = "IX_SubCategories_CategoryId")]
public partial class SubCategory
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    [InverseProperty("SubCategory")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [ForeignKey("CategoryId")]
    [InverseProperty("SubCategories")]
    public virtual Category Category { get; set; } = null!;
}
