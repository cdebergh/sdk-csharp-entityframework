using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Model;
using Example.Data;
using Example.Data.Repositories;
using Example.Data.Abstract;

namespace Example.Data.Repositories
{
    public class ExampleRepository : EntityBaseRepository<ExampleEntity>, IExampleRepository
    {
        public ExampleRepository(ExampleContext context)
            : base(context)
        { }
    }
}
