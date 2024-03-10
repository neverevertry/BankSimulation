using Domain.Entities;

namespace Domain.Interface
{
    public interface IOperationRepository
    {
        Task AddAsync(Operation description);
    }
}
