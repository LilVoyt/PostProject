using PostProject.DataAcces.Entities;

namespace PostProject.DataAcces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> PostAsync(Client client);
    }
}