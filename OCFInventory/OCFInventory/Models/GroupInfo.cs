using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace OCFInventory.Models
{
    public class GroupInfo
    {
         
        public virtual int Id { get; set; }  

        public virtual string Name { get; set; } 

        [Required(ErrorMessage = "The Description is required.")]
        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        public virtual DateTime LastUpdated { get; set; } 

        public virtual int LastUpdatedBy { get; set; } 

        public virtual int Domain { get; set; } 


        [HiddenInput]
        public virtual int Parent { get; set; } 

        [HiddenInput]
        public virtual int Root { get; set; } 



    }
}