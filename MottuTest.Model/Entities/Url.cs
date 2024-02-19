using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Model.Models
{
  public class UrlDto : BaseEntity
  {
    [Required]
    [DefaultValue(0)]
    public int Hits { get; set; }
    [Required]
    [MaxLength(120)]
    public string OriginalUrl { get; set; }
    [Required]
    [MaxLength(120)]
    public string ShortUrl { get; set; }
  }
}
