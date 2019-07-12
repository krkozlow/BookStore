using DBookStore.Client.Api.Models;
using System;
using System.Collections.Generic;

public class BookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Release { get; set; }
    public string Genre { get; set; }
    public IEnumerable<ReviewDto> Reviews { get; set; }
}