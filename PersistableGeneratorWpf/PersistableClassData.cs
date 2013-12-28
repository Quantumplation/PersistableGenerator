using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistableGeneratorWpf
{
    public partial class PersistableClass
    {
        public PersistableClass(Persistable persistable)
        {
            Namespace = persistable.Namespace;
            Name = persistable.Name;
            Properties = persistable.Fields.Select(x => new Property(x)).ToList();
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; } 
    }
}
