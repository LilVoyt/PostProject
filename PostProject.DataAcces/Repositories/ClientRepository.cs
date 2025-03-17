using PostProject.DataAcces.Data;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Repositories
{
    public class ClientRepository(DataContext dataContext)
    {
        public async Task<Client> PostAsync(Client client)
        {
            await dataContext.AddAsync(client);
            await dataContext.SaveChangesAsync();
            return client;
        }

        //public async Task<IEnumerable<Client>> GetAllAsync()
        //{
        //    await
        //}
    }
}
