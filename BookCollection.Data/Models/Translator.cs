using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("UserId", Name = "IX_Translators_UserId")]
public partial class Translator
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UserId { get; set; }

    [InverseProperty("Translator")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [ForeignKey("UserId")]
    [InverseProperty("Translators")]
    public virtual AspNetUser? User { get; set; }
}
