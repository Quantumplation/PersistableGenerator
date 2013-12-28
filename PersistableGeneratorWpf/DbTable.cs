using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PersistableGeneratorWpf.Annotations;

namespace PersistableGeneratorWpf
{
    public class DbTable : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<DbColumn> _columns;
        private DbColumn _primaryKey;
        private bool _baseTable;
        private int _selectedDbColumnIndex;
        public event PropertyChangedEventHandler PropertyChanged;

        public DbTable()
        {
            _selectedDbColumnIndex = -1;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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

        public DbColumn PrimaryKey
        {
            get { return _primaryKey; }
            set
            {
                if (Equals(value, _primaryKey)) return;
                _primaryKey = value;
                OnPropertyChanged();
            }
        }

        public bool IsBaseTable
        {
            get { return _baseTable; }
            set
            {
                if (value.Equals(_baseTable)) return;
                _baseTable = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DbColumn> Columns
        {
            get { return _columns; }
            set
            {
                if (Equals(value, _columns)) return;
                _columns = value;
                OnPropertyChanged();
            }
        }

        public int SelectedDbColumnIndex
        {
            get { return _selectedDbColumnIndex; }
            set
            {
                if (value == _selectedDbColumnIndex) return;
                _selectedDbColumnIndex = value;
                OnPropertyChanged();
                OnPropertyChanged("SelectedDbColumn");
            }
        }

        public DbColumn SelectedDbColumn
        {
            get
            {
                if (Columns == null || SelectedDbColumnIndex < 0 || SelectedDbColumnIndex >= Columns.Count)
                    return null;
                return Columns.ElementAt(SelectedDbColumnIndex);
            }
        }
    }
}
