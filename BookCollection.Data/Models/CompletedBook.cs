using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("BookId", Name = "IX_CompletedBooks_BookId")]
[Index("UserId", Name = "IX_CompletedBooks_UserId")]
public partial class CompletedBook
{
    [Key]
    public int Id { get; set; }

    public int BookId { get; set; }

    public string? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public DateTime BuyingDate { get; set; }

    public DateTime? ReadingStartDate { get; set; }

    public DateTime? ReadingEndDate { get; set; }

    public string AuthorName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string SubCategoryName { get; set; } = null!;

    [ForeignKey("BookId")]
    [InverseProperty("CompletedBooks")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("CompletedBooks")]
    public virtual AspNetUser? User { get; set; }
}
