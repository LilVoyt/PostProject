using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PostProject.DataAcces.Data;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Repositories
{
    public class ClientRepository(DataContext dataContext) : IClientRepository
    {
        public async Task<Client> PostAsync(Client client)
        {
            var res = await dataContext.Clients.FirstOrDefaultAsync(c => c.PhoneNumber == client.PhoneNumber);

            if (res != null)
            {
                await dataContext.AddAsync(client);
                await dataContext.SaveChangesAsync();
                return client;
            }
            else
            {
                throw new DataException($"User with this phone number: \"{client.PhoneNumber}\" alredy exist");
            }
        }

        //public async Task<IEnumerable<Client>> GetAllAsync()
        //{
        //    await
        //}
    }
}
