using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LeapYear.Models;
public class PersonYear
{
    [Display(Name = "Rok")]
    [Required(ErrorMessage ="Pole rok jest wymagane")]
    [Range(1899,2022,ErrorMessage ="Rok musi mieścić się w zakresie od 1899 do 2022")]
    public int? Year { get; set; }


    [Display(Name = "Imię")]
    [Required(ErrorMessage = "Pole imię jest wymagane")]
    [MaxLength(100)]
    public string Name { get; set; }
    public string CheckIfLeapYear()
    {
        int? year = this.Year;
        if (year % 4 != 0)
            return "nie był";
        else if (year % 100 != 0)
            return "był";
        else if (year % 400 != 0)
            return "nie był";
        else
            return "był";
    }
}
