using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistableGenerator
{
    public partial class PersistableDefinition
    {
        public string Namespace
        {
            get; set;
        }

        public string PersistableName
        {
            get; set;
        }

        public IEnumerable<Property> Properties
        {
            get;
            set;
        }

    }
}
