using LibraryBookManagement1.Validtators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibraryBookManagement.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        [Unique]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bio is required.")]
        [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
        public string Bio { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        
        public ICollection<Book>? Books { get; set; }
    }
}
