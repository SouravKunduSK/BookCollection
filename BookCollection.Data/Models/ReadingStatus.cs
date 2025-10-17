using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

public partial class ReadingStatus
{
    [Key]
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    [InverseProperty("ReadingStatus")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
