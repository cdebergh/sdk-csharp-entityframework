using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class ExampleEntity : IEntityBase
    {
        public ExampleEntity() { }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
