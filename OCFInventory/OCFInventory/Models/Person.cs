using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCFInventory.Models
{
    public class Person
    {
        
        public virtual int ID { get; set; }

        [Required(ErrorMessage = "The First Name is required.")]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public virtual string MiddleName { get; set; }

        [Required(ErrorMessage = "The Last Name is required.")]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public virtual DateTime? BirthDate { get; set; } 

        public virtual string Email { get; set; } 

        public virtual string Phone { get; set; }

        [Display(Name = "Nick Name")]
        public virtual string NickName { get; set; } 

        public virtual string Address { get; set; } 

        public virtual string City { get; set; } 

        public virtual string State { get; set; }

        [Display(Name = "Postal Code")]
        public virtual string PostalCode { get; set; } 

        public virtual string  Country { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string  Notes { get; set; } 


    }
}