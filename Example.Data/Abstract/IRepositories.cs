using Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Data.Abstract
{
    public interface IExampleRepository : IEntityBaseRepository<ExampleEntity> { }
}
