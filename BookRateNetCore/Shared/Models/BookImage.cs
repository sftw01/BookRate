using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Models
{
    public class BookImage
    {
        public Guid Id { get; set; }
        public byte[]? Image { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }     // Navigation property to Book


        public BookImage(byte[] image, Guid bookId)
        {
            Id = Guid.NewGuid(); // Generowanie unikalnego identyfikatora
            Image = image;
            BookId = bookId;     // Ustawienie klucza obcego
        }

    }
}
