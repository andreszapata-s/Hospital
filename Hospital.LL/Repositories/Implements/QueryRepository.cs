using Hospital.BL.Data;
using Hospital.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.LL.Repositories.Implements
{
    public class QueryRepository : GenericRepository<Query>, IQueryRepository
    {
        public QueryRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
        }
    }
}
