﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int Rate { get; set; }
        public byte[]? CoverImage { get; set; }
        public List<BookImage>? Images { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        //public DateTime? CreatedAt { get; set; }
        public int? Pages { get; set; }

    }
}
