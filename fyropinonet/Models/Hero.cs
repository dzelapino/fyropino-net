using System.ComponentModel.DataAnnotations;

namespace fyropinonet.Models;

public class Hero
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public String Name { get; set; }
    
    public Boolean IsForceUser { get; set; }
}