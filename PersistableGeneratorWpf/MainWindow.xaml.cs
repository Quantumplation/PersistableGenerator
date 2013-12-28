using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScintillaNET;
using CheckBox = System.Windows.Controls.CheckBox;
using TabControl = System.Windows.Controls.TabControl;

namespace PersistableGeneratorWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Persistable CurrentPersistable
        {
            get; set;
        }
        public MainWindow()
        {
            InitializeComponent();
            CurrentPersistable = new Persistable
            {
                Fields = new ObservableCollection<Field> {new Field {Name = "Test", Type = "string"}},
                Tables = new ObservableCollection<DbTable>
                    {
                        new DbTable
                        {
                            Name = "Test", 
                            Columns = new ObservableCollection<DbColumn>
                            {
                                new DbColumn {Name = "Test"}
                            }
                        },
                        new DbTable
                        {
                            Name = "Test2",
                            Columns = new ObservableCollection<DbColumn>
                            {
                                new DbColumn { Name = "Test2"},
                                new DbColumn { Name = "Test3"}
                            }
                        }
                    }
            };
            foreach (var tbl in CurrentPersistable.Tables)
            {
                tbl.PrimaryKey = tbl.Columns.First();
            }
            DataContext = CurrentPersistable;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (((CheckBox) sender).IsChecked ?? false)
            {
                foreach (var tbl in CurrentPersistable.Tables)
                {
                    if (tbl == CurrentPersistable.SelectedDbTable)
                        continue;
                    tbl.IsBaseTable = false;
                }
            }
        }

        private void Add_Table_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersistable.Tables.Add(new DbTable { Name = "NewTable", Columns = new ObservableCollection<DbColumn>() });
            CurrentPersistable.SelectedTableIndex = CurrentPersistable.Tables.Count - 1;
        }

        private void Remove_Table_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersistable.Tables.Remove(CurrentPersistable.SelectedDbTable);
        }

        private void Add_Column_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersistable.SelectedDbTable.Columns.Add(new DbColumn { Name = "NewColumn" });
            CurrentPersistable.SelectedDbTable.SelectedDbColumnIndex =
                CurrentPersistable.SelectedDbTable.Columns.Count - 1;
        }

        private void Remove_Column_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersistable.SelectedDbTable.Columns.Remove(CurrentPersistable.SelectedDbTable.SelectedDbColumn);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl && ((TabControl)e.Source).SelectedItem == Class_Tab)
            {
                var classCode = new PersistableClass(CurrentPersistable);
                sourceEditor.ConfigurationManager.Language = "cs";
                sourceEditor.Text = classCode.TransformText();
            }
        }

        private Scintilla sourceEditor;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
            var host = new System.Windows.Forms.Integration.WindowsFormsHost();
            sourceEditor = new Scintilla();
            sourceEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            host.Child = sourceEditor;
            Class_Grid.Children.Add(host);
        }
    }
}
