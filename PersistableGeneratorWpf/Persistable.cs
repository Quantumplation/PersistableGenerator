using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using PersistableGeneratorWpf.Annotations;

namespace PersistableGeneratorWpf
{
    public class Persistable : INotifyPropertyChanged
    {
        private string _ns;
        private string _name;
        private ObservableCollection<Field> _fields;
        private ObservableCollection<DbTable> _tables;
        private int _selectedTableIndex;
        public event PropertyChangedEventHandler PropertyChanged;

        public Persistable()
        {
            _ns = "UnnamedNamespace";
            _name = "UnnamedPersistable";
            _fields = new ObservableCollection<Field>();
            _tables = new ObservableCollection<DbTable>();
            _selectedTableIndex = 0;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Namespace
        {
            get { return _ns; }
            set
            {
                if (value == _ns) return;
                _ns = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Field> Fields
        {
            get { return _fields; }
            set
            {
                if (Equals(value, _fields)) return;
                _fields = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DbTable> Tables
        {
            get { return _tables; }
            set
            {
                if (Equals(value, _tables)) return;
                _tables = value;
                OnPropertyChanged();
            }
        }

        public int SelectedTableIndex
        {
            get { return _selectedTableIndex; }
            set
            {
                if (value == _selectedTableIndex) return;
                _selectedTableIndex = value;
                OnPropertyChanged();
                OnPropertyChanged("SelectedDbTable");
            }
        }

        public DbTable SelectedDbTable 
        {
            get
            {
                if (Tables == null || SelectedTableIndex < 0 || SelectedTableIndex >= Tables.Count)
                    return null;
                return Tables.ElementAt(SelectedTableIndex);
            } 
        }

        public void AddDbTable(DbTable table)
        {
            Tables.Add(table);
            OnPropertyChanged("Tables");
        }
    }
}
