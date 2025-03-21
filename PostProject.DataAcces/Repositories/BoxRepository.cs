using PostProject.DataAcces.Data;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.DataAcces.Repositories
{
    public class BoxRepository(DataContext dataContext) : IBoxRepository
    {
        public async Task<List<Guid>> PostBoxesAsync(List<Box> boxes)
        {
            await dataContext.AddRangeAsync(boxes);
            await dataContext.SaveChangesAsync();
            return boxes.Select(x => x.Id).ToList();
        }
    }
}
