using System.Collections.Generic;
using PersistableGenerator;

namespace VendorEntities
{
    public class Vendor : Persistable
    {
        internal class Properties : IProperties
        {
            internal IProperty<string> PrimaryName = new Property<string>();
            internal IProperty<Person> Contact = new PersistableProperty<Person>();
            internal ICollectionProperty<string> AlternateNames = new CollectionProperty<string>();
            internal ICollectionProperty<Address> Addresses = new PersistableCollectionProperty<Address>();
        }

        internal Properties properties = new Properties();

        public string PrimaryName
        {
            get
            {
                return properties.PrimaryName.Get(Id.AsOf);
            }
            set
            {
                properties.PrimaryName.Set(Id.AsOf, value);
            }
        }
        public Person Contact
        {
            get
            {
                return properties.Contact.Get(Id.AsOf);
            }
            set
            {
                properties.Contact.Set(Id.AsOf, value);
            }
        }
        public ICollection<string> AlternateNames
        {
            get
            {
                return properties.AlternateNames.Get(Id.AsOf);
            }
            set
            {
                properties.AlternateNames.Set(Id.AsOf, value);
            }
        }
        public ICollection<Address> Addresses
        {
            get
            {
                return properties.Addresses.Get(Id.AsOf);
            }
            set
            {
                properties.Addresses.Set(Id.AsOf, value);
            }
        }
    }
}