using System.ComponentModel.DataAnnotations;

namespace fyropinonet.Models;

public class AddContractorViewModel
{
    public string ShortName { get; set; }
    
    public string FullName { get; set; }

    public string Address { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }
    
    public string Color { get; set; }
}