using Microsoft.AspNetCore.Mvc.Rendering;

namespace fyropinonet.Models;

public class AddTaskViewModel
{
    
    public List<String> SelectedContractorIdList { get; set; }
    
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public List<SelectListItem> ContractorsSelectListItems { get; set; }

    public AddTaskViewModel()
    {
        
    }
    
    public AddTaskViewModel(List<SelectListItem> contractorsSelectListItems)
    {
        SelectedContractorIdList = new List<string>();
        Name = "";
        StartDate = DateTime.Now;
        EndDate = DateTime.Now;
        ContractorsSelectListItems = contractorsSelectListItems;
    }
}