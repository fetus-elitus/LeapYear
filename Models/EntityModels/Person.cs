using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EntityModels;
public class Person
{
    public int PersonId { get; set; }

    [Display(Name = "Rok")]
    [Required(ErrorMessage ="Pole rok jest wymagane")]
    [Range(1899,2022,ErrorMessage ="Rok musi mieścić się w zakresie od 1899 do 2022")]
    public int? Year { get; set; }

    public bool IsActive { get; set; }
    public AppUser? User { get; set; }   

    [Display(Name = "Imię")]
    [Required(ErrorMessage = "Pole imię jest wymagane")]
    [MaxLength(100)]
    public string Name { get; set; }
    [Display(Name= "Nazwisko")]
    [MaxLength(100)]
    public string? LastName { get; set; }
    public DateTime DataRetrievedTime { get; set; }
    public bool IsLeapYear { get; set; }
    public void CheckIfLeapYear()
    {
        if ((this.Year % 4 == 0 || this.Year % 400 == 0) && this.Year % 100 != 0)
            IsLeapYear = true;
        else
            IsLeapYear = false;
    }
}
