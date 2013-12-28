using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistableGenerator
{
    public class Table
    {
        public string Name { get; set; }

        public List<Column> Columns;

        public override string ToString()
        {
            return Name;
        }
    }

    public class Column
    {
        public string Name;
    }
}
