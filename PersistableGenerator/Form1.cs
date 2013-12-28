using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET.Configuration;

namespace PersistableGenerator
{
    public partial class Form1 : Form
    {
        private BindingList<Table> tables = new BindingList<Table>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scintilla1.ConfigurationManager.Language = "cs";
            scintilla2.ConfigurationManager.Language = "cs";
            scintilla3.ConfigurationManager.Language = "mssql";

            txtNamespace.Text = "VendorEntities";
            txtName.Text = "Vendor";

            dataGridView1.Rows.Add("PrimaryName", "string", false, false);
            dataGridView1.Rows.Add("Names", "string", false, true);
            dataGridView1.Rows.Add("Contact", "Person", true, false);
            dataGridView1.Rows.Add("Addresses", "Address", true, true);

            listBox1.DataSource = tables;
            textBox1.DataBindings.Add("Text", tables, "Name");
        }

        private Property MakeProperty(DataGridViewRow row)
        {
            if (row.IsNewRow) return null;
            var isPersistable = (bool) (row.Cells[2].Value ?? false);
            var isCollection = (bool) (row.Cells[3].Value ?? false);
            var propType = isPersistable ? PropertyType.Persistable : PropertyType.Generic;
            if (isCollection) propType |= PropertyType.Collection;

            return new Property
            {
                Name = (string)row.Cells[0].Value,
                ClrTypeName = (string)row.Cells[1].Value,
                Type = propType
            };
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rows = dataGridView1.Rows.Cast<DataGridViewRow>();

            var properties = rows.Select(MakeProperty).Where(x => x != null).ToList();

            var persistableClass = new PersistableClass()
            {
                Namespace = txtNamespace.Text,
                PersistableName = txtName.Text,
                Properties = properties
            };
            scintilla1.Text = persistableClass.TransformText();

            var persistableDefinition = new PersistableDefinition()
            {
                Namespace = txtNamespace.Text,
                PersistableName = txtName.Text,
                Properties = properties
            };

            scintilla2.Text = persistableDefinition.TransformText();


            scintilla3.Text = @"SELECT * FROM Sample";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tables.Add(new Table {Name = "NewTable", Columns = new List<Column>()});
        }
    }
}
