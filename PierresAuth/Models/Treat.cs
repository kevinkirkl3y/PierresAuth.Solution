using System.Collections.Generic;
using System;

namespace PierresAuth.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }
    public int TreatId { get; set; }
    public string TreatType { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<FlavorTreat> Flavors { get; set; }
  }
    
}