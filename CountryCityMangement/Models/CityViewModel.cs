using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryCityMangement.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
      
      
        public string CityName { get; set; }
        [Required]
        [AllowHtml]
        public string About { get; set; }
        [Required]
        [Display(Name = "No. of dwellers")]
        public double NoOfDweller { get; set; }
        [Required]
        public string Location { get; set; }
        //[HiddenInput(DisplayValue = false)]
        [Required]
        public string Weather { get; set; }
       
        public int CoutEntryId { get; set; }
        public CountryEntry CoutEntry { get; set; }
        public string SerchedValue { get; set; }
    }
}