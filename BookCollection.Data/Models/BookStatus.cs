using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

public partial class BookStatus
{
    [Key]
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    [InverseProperty("BookStatus")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [InverseProperty("BookStatus")]
    public virtual ICollection<Lending> Lendings { get; set; } = new List<Lending>();
}
