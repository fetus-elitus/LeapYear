using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels;

public class PersonViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool IsUsers { get; set; }
}
