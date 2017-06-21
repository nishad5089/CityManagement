using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryCityMangement.Models
{
    public class CountryEntry
    {
        public int Id { get; set; }
       [Display(Name ="Name")]
        [Remote("IsCountryExist", "CountryEntries",ErrorMessage = "Courtry Already Exist")]
        [Required]
        public string CountyName { get; set; }
        [Required]
        [AllowHtml]
        public string About { get; set; }

        
    }
}