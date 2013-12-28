using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistableGeneratorWpf
{    
    [Flags]
    public enum PropertyType
    {
        Generic = 1,
        Persistable = 2,
        Collection = 4
    }

    public class Property
    {
        public Property(Field field)
        {
            Name = field.Name;
            ClrTypeName = field.Type;
            Type = (field.IsPersistable ? PropertyType.Persistable : PropertyType.Generic) | (field.IsCollection ? PropertyType.Collection : 0);
        }
        public string Name
        {
            get;
            set;
        }

        public string ClrTypeName
        {
            get;
            set;
        }

        public PropertyType Type
        {
            get;
            set;
        }

        public string DbTable
        {
            get;
            set;
        }

        public string DbColumn
        {
            get;
            set;
        }

        public string Definition()
        {
            const string PropertyDefinition =
                @"internal I{0}Property<{1}> {2} = new {3}{0}Property<{1}>();";
            var isCollection = (Type & PropertyType.Collection) != 0;
            var isPersistable = (Type & PropertyType.Persistable) != 0;
            return String.Format(PropertyDefinition, isCollection ? "Collection" : "", ClrTypeName, Name, isPersistable ? "Persistable" : "");
        }

        public string AccessorSignature()
        {
            const string AccessorSignature =
                @"public {0} {1}";
            var isCollection = (Type & PropertyType.Collection) != 0;
            var type = isCollection ? String.Format("ICollection<{0}>", ClrTypeName) : ClrTypeName;
            return String.Format(AccessorSignature, type, Name);
        }

        public string AccessorGet()
        {
            const string AccessorGet =
                @"return properties.{0}.Get(Id.AsOf);";
            return String.Format(AccessorGet, Name);
        }

        public string AccessorSet()
        {
            const string AccessorSet =
                @"properties.{0}.Set(Id.AsOf, value);";
            return String.Format(AccessorSet, Name);
        }
    }
}
