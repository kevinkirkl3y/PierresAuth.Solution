using System.Collections.Generic;
using System;

namespace PierresAuth.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<FlavorTreat>();
    }
    public int FlavorId { get; set; }
    public string FlavorType { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<FlavorTreat> Treats { get; set; }
  }
}