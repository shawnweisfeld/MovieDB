using System;

namespace MovieDB.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string BoxCoverUrl { get; set; }
        public decimal Price { get; set; }
    }
}