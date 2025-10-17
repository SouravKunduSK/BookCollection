using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

[Index("AuthorId", Name = "IX_Books_AuthorId")]
[Index("BookStatusId", Name = "IX_Books_BookStatusId")]
[Index("CategoryId", Name = "IX_Books_CategoryId")]
[Index("ReadingStatusId", Name = "IX_Books_ReadingStatusId")]
[Index("SubCategoryId", Name = "IX_Books_SubCategoryId")]
[Index("TranslatorId", Name = "IX_Books_TranslatorId")]
[Index("UserId", Name = "IX_Books_UserId")]
public partial class Book
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string? UserId { get; set; }

    public int AuthorId { get; set; }

    public int TranslatorId { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public DateTime BuyingDate { get; set; }

    public DateTime? ReadingStartDate { get; set; }

    public DateTime? ReadingEndDate { get; set; }

    public int ReadingStatusId { get; set; }

    public int BookStatusId { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Books")]
    public virtual Author Author { get; set; } = null!;

    [ForeignKey("BookStatusId")]
    [InverseProperty("Books")]
    public virtual BookStatus BookStatus { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Books")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Book")]
    public virtual ICollection<CompletedBook> CompletedBooks { get; set; } = new List<CompletedBook>();

    [InverseProperty("Book")]
    public virtual ICollection<Lending> Lendings { get; set; } = new List<Lending>();

    [ForeignKey("ReadingStatusId")]
    [InverseProperty("Books")]
    public virtual ReadingStatus ReadingStatus { get; set; } = null!;

    [ForeignKey("SubCategoryId")]
    [InverseProperty("Books")]
    public virtual SubCategory SubCategory { get; set; } = null!;

    [ForeignKey("TranslatorId")]
    [InverseProperty("Books")]
    public virtual Translator Translator { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Books")]
    public virtual AspNetUser? User { get; set; }
}
