using Hospital.BL.Models;
using Hospital.LL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.LL.Services.Implements
{
    public class QueryServices : GenericService<Query>, IQueryServices
    {
        public QueryServices(IGenericRepository<Query> genericRepository) : base(genericRepository)
        {
        }
    }
}
