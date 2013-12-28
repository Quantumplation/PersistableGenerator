using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistableGenerator
{
    public class Persistable
    {
        public interface IProperties { }

        public class Identity
        {
            public int AsOf;
        }

        public Identity Id;
    }

    public interface IProperty<T>
    {
        T Get(int asOf);
        void Set(int asOf, T val);
    }

    public interface ICollectionProperty<T>
    {
        ICollection<T> Get(int asOf);
        void Set(int asOf, ICollection<T> value);
    }

    public class Property<T> : IProperty<T>
    {
        public T Get(int asOf)
        {
            throw new System.NotImplementedException();
        }

        public void Set(int asOf, T val)
        {
            throw new System.NotImplementedException();
        }
    }
    public class PersistableProperty<T> : IProperty<T> where T : Persistable
    {
        public T Get(int asOf)
        {
            throw new System.NotImplementedException();
        }

        public void Set(int asOf, T val)
        {
            throw new System.NotImplementedException();
        }
    }
    public class CollectionProperty<T> : ICollectionProperty<T>
    {
        public ICollection<T> Get(int asOf)
        {
            throw new System.NotImplementedException();
        }

        public void Set(int asOf, ICollection<T> value)
        {
            throw new System.NotImplementedException();
        }
    }
    public class PersistableCollectionProperty<T> : ICollectionProperty<T>
    {
        public ICollection<T> Get(int asOf)
        {
            throw new System.NotImplementedException();
        }

        public void Set(int asOf, ICollection<T> value)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Address : Persistable { }

    public class Person : Persistable
    {
    }

}
