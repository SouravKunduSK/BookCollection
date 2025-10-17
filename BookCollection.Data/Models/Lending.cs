using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("BookId", Name = "IX_Lendings_BookId")]
[Index("BookStatusId", Name = "IX_Lendings_BookStatusId")]
[Index("UserId", Name = "IX_Lendings_UserId")]
public partial class Lending
{
    [Key]
    public int Id { get; set; }

    public int BookId { get; set; }

    public string? UserId { get; set; }

    public string BorrowerName { get; set; } = null!;

    public DateTime LendDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int BookStatusId { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Lendings")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("BookStatusId")]
    [InverseProperty("Lendings")]
    public virtual BookStatus BookStatus { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Lendings")]
    public virtual AspNetUser? User { get; set; }
}
