using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("UserId", Name = "IX_Authors_UserId")]
public partial class Author
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UserId { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [ForeignKey("UserId")]
    [InverseProperty("Authors")]
    public virtual AspNetUser? User { get; set; }
}
