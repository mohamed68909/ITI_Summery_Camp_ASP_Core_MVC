using LibraryBookManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement1.Validtators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LibraryContext db = new LibraryContext();
            string name = value as string;

            var emp = db.Authors.FirstOrDefault(e => e.Name == name);
            if (emp != null)
            {
                return new ValidationResult("Name already Exist !!!");
            }
            return ValidationResult.Success;
           

        }
    }
    
    }

