using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PersistableGeneratorWpf.Annotations;

namespace PersistableGeneratorWpf
{
    public class Field : INotifyPropertyChanged
    {
        private string _name;
        private string _type;
        private bool _isPersistable;
        private bool _isCollection;
        private DbTable _table;
        private DbColumn _column;
        public event PropertyChangedEventHandler PropertyChanged;

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

        public string Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }

        public bool IsPersistable
        {
            get { return _isPersistable; }
            set
            {
                if (value.Equals(_isPersistable)) return;
                _isPersistable = value;
                OnPropertyChanged();
            }
        }

        public bool IsCollection
        {
            get { return _isCollection; }
            set
            {
                if (value.Equals(_isCollection)) return;
                _isCollection = value;
                OnPropertyChanged();
            }
        }

        public DbTable Table
        {
            get { return _table; }
            set
            {
                if (Equals(value, _table)) return;
                _table = value;
                OnPropertyChanged();
            }
        }

        public DbColumn Column
        {
            get { return _column; }
            set
            {
                if (Equals(value, _column)) return;
                _column = value;
                OnPropertyChanged();
            }
        }
    }
}
