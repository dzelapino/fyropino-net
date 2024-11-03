using fyropinonet.Contracts;
using fyropinonet.Migrations;
using fyropinonet.Models;

namespace fyropinonet.Interface;

public interface IContractorServices
{
    Task<IEnumerable<Contractor>> GetAllContractorsAsync();
    
    Task<Contractor> GetContractorById(int id);
    
    Task CreateContractor(CreateContractorRequest createContractorRequest);
    
    Task UpdateContractor(int id, UpdateContractorRequest updateContractorRequest);
    
    Task DeleteContractor(int id);
}