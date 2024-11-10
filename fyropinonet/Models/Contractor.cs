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
    [MaxLength(20)]
    public string ShortName { get; set; }
    
    [MaxLength(50)]
    public string FullName { get; set; }

    public bool IsActive { get; set; } = true;
    
    [MaxLength(50)]
    public string Address { get; set; }
    
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Phone]
    [MaxLength(20)]
    public string Phone { get; set; }
    
    [MaxLength(20)]
    public string Color { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}