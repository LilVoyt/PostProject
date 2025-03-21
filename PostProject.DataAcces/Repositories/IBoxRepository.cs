using PostProject.DataAcces.Entities;

namespace PostProject.DataAcces.Repositories
{
    public interface IBoxRepository
    {
        Task<List<Guid>> PostBoxesAsync(List<Box> boxes);
    }
}