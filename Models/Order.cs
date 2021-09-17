﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(15)]
        [MaxLength(10)]
        public string FirstName { get; set; }
       
        
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(10)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please enter your House/Flat/Block no.")]
        [StringLength(100)]
        [Display(Name ="House/Flat/Block no.")]
        public string Address1 { get; set; }

        [Display(Name = "Apartment/Road/Area (Optional)")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please enter your Pincode")]
        [StringLength(6,MinimumLength =6)]
        [Display(Name = "Pin code")]
      
        public string Pincode { get; set; }

        [Required(ErrorMessage ="Please enter your City")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your State")]
        [StringLength(50)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your Country")]
        [StringLength(50)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your Phone number")]
        [StringLength(13)]
        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Email ")]
        [StringLength(25)]
        [Display(Name = "Email Address")]
      //  [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
