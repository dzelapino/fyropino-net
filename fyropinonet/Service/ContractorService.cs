using AutoMapper;
using fyropinonet.Contracts;
using fyropinonet.Controllers.Data;
using fyropinonet.Interface;
using fyropinonet.Migrations;
using fyropinonet.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace fyropinonet.Service;

public class ContractorService : IContractorServices
{
    private readonly IMapper _mapper;
    private readonly ApplicationDBContext _context;
    private readonly ILogger<ContractorService> _logger;

    public ContractorService(IMapper mapper, ApplicationDBContext context, ILogger<ContractorService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Contractor>> GetAllContractorsAsync()
    {
        var contractors = await _context.Contractors.ToListAsync();

        return contractors;
    }

    public Task<Contractor> GetContractorById(int id)
    {
        try
        {
            var contractor = _context.Contractors.Find(id);
            return Task.FromResult(contractor);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to get creator by id: " + id);
        }
    }

    public async Task CreateContractor(CreateContractorRequest createContractorRequest)
    {
        try
        {
            var contractor = _mapper.Map<Contractor>(createContractorRequest);
            _context.Contractors.Add(contractor);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Failed to create contractor");
        }
    }

    public Task UpdateContractor(int id, UpdateContractorRequest updateContractorRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteContractor(int id)
    {
        throw new NotImplementedException();
    }
}