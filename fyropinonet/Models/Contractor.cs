using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace fyropinonet.Models;

public class Contractor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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