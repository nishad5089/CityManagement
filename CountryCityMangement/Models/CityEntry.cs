using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace CountryCityMangement.Models
{
    public class CityEntry
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
         [Remote("IsCityExist","CityEntries",ErrorMessage = "City Name Already Exist")]
        [Required]
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
        [Required]
        public int CoutEntryId { get; set; }
        public CountryEntry CoutEntry { get; set; }
        
    }
}