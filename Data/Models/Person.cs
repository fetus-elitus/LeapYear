using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;
public class Person
{
    public int PersonId { get; set; }

    [Display(Name = "Rok")]
    [Required(ErrorMessage ="Pole rok jest wymagane")]
    [Range(1899,2022,ErrorMessage ="Rok musi mieścić się w zakresie od 1899 do 2022")]
    public int Year { get; set; }


    [Display(Name = "Imię")]
    [Required(ErrorMessage = "Pole imię jest wymagane")]
    [MaxLength(100)]
    public string Name { get; set; }
    [Display(Name= "Nazwisko")]
    [MaxLength(100)]
    public string? LastName { get; set; }
    public DateTime DataRetrievedTime { get; set; }
    [Column]
    public bool IsLeapYear { get => CheckIfLeapYear(this.Year); private set => IsLeapYear = IsLeapYear; }
    
    private bool CheckIfLeapYear(int year)
    {
        if ((year % 4 == 0 || year % 400 == 0) && year % 100 != 0)
            return true;
        else
            return false;
    }
}
