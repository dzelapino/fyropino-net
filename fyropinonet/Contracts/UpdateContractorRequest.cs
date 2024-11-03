using System.ComponentModel.DataAnnotations;

namespace fyropinonet.Contracts;

public class UpdateContractorRequest
{
    [StringLength(20)]
    public string ShortName { get; set; }

    [StringLength(100)]
    public string FullName { get; set; }
    
    public string Address { get; set; }    

    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }

    public string Color { get; set; }
}