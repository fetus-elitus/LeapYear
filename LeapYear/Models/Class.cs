using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LeapYear.Models;
[BindProperties]
public class PersonYear
{

    [Range(1899,2022,ErrorMessage ="Year must be in range of 1899-2022")]
    public int Year { get; set; }
    [Range(0,100)]
    public string Name { get; set; }
}
