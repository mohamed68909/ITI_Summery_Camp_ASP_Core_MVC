using LibraryBookManagement1.Validtators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement.Models
{
    public enum Category
    {
        Novel,
        Fiction,
        Science,
        History,
        Biography,
        Romance,
        Other
    }

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="is max lenght 100 ")]
        [Display(Name = "Book Title")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Title can only contain letters, numbers, and spaces.")]
        
        public string Title { get; set; }

        [Required]
        public Category Category { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime PublicationDate { get; set; }


        [Display(Name = "Available")]
        [Required(ErrorMessage = "Availability is required.")]
        public bool IsAvailable { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}
