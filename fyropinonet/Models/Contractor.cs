using System.ComponentModel.DataAnnotations;

namespace fyropinonet.Models;

public class Contractor
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string ShortName { get; set; }
    
    public string FullName { get; set; }

    public bool IsActive { get; set; }
    
    public string Address { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }
    
    public string Color { get; set; }

    public Contractor()
    {
        this.IsActive = true;
    }
}