using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interface;

namespace DataAccess.Repository
{
    public class EFOperationRepository : IOperationRepository
    {
        public ApplicationDbContext _context;

        public EFOperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Operation description)
        {
            await _context.AddAsync(description);
            
            await _context.SaveChangesAsync();
        }
    }
}
