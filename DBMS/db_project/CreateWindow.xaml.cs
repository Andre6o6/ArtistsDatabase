using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace db_project
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        Database db;
        string fields = "";
        string tables = "";
        string where = "";
        string[] foreignKeys;
        bool main;

        public CreateWindow()
        {
            InitializeComponent();
        }
        public CreateWindow(Database db, string table = "")
        {
            InitializeComponent();
            this.db = db;
            main = true;

            if (table != "")
            {
                tableSelectionComboBox.Text = table;
                tableSelectionComboBox.IsEnabled = false;
                tableSelectionComboBox_DropDownClosed(this, null);

                buttonXMLExport.Visibility = Visibility.Hidden;
                buttonXMLImport.Visibility = Visibility.Hidden;
                richTextBox.Visibility = Visibility.Hidden;

                main = false;
            }

            if (main && !db.InTransaction())
            {
                db.xml = new System.Data.DataSet("create");
                db.BeginTransaction();
            }
        }

        string GetFKFields(string table)
        {
            switch (table)
            {
                case "painting":
                    return "artist_id";
                case "exhibition":
                    return "address_id";
                case "auction":
                    return "address_id";
                case "address":
                    return "city_id";
                case "city":
                    return "country_id";
            }
            return "";
        }

        void UpdateComboBoxes()
        {
            System.Data.DataView a;
            string[] s;
            switch (tableSelectionComboBox.Text)
            {
                case "Artist":
                    tables = "artist";
                    fields = "first_name, last_name";
                    where = "artist_id = 1";

                    labelAdd.Visibility = Visibility.Hidden;
                    addComboBox.Visibility = Visibility.Hidden;
                    buttonAdd.Visibility = Visibility.Hidden;
                    break;
                case "Painting":
                    tables = "painting";
                    fields = "title, technique";
                    where = "painting_id = 1";

                    labelAdd.Visibility = Visibility.Visible;
                    addComboBox.Visibility = Visibility.Visible;
                    buttonAdd.Visibility = Visibility.Visible;

                    labelAdd.Content = "Author";
                    a = db.ExecuteQuery("SELECT artist_id, first_name, last_name FROM artist");
                    s = new string[a.Table.Rows.Count];
                    foreignKeys = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreignKeys[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + " " + a.Table.Rows[i].ItemArray[2].ToString();
                    }
                    addComboBox.ItemsSource = s;

                    break;
                case "Exhibition":
                    tables = "exhibition";
                    fields = "exhibition_name";
                    where = "exhibition_id = 1";

                    labelAdd.Visibility = Visibility.Visible;
                    addComboBox.Visibility = Visibility.Visible;
                    buttonAdd.Visibility = Visibility.Visible;

                    labelAdd.Content = "Address";
                    a = db.ExecuteQuery("SELECT address_id, address FROM address");
                    s = new string[a.Table.Rows.Count];
                    foreignKeys = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreignKeys[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    addComboBox.ItemsSource = s;

                    break;
                case "Auction":
                    tables = "auction";
                    fields = "auction_name";
                    where = "auction_id = 1";

                    labelAdd.Visibility = Visibility.Visible;
                    addComboBox.Visibility = Visibility.Visible;
                    buttonAdd.Visibility = Visibility.Visible;

                    labelAdd.Content = "Address";
                    a = db.ExecuteQuery("SELECT address_id, address FROM address");
                    s = new string[a.Table.Rows.Count];
                    foreignKeys = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreignKeys[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    addComboBox.ItemsSource = s;

                    break;
                case "Site":
                    tables = "internet_site";
                    fields = "site";
                    where = "site_id = 1";

                    labelAdd.Visibility = Visibility.Hidden;
                    addComboBox.Visibility = Visibility.Hidden;
                    buttonAdd.Visibility = Visibility.Hidden;
                    break;
                case "Address":
                    tables = "address";
                    fields = "address, district, postal_code, phone";
                    where = " address_id = 1";

                    labelAdd.Visibility = Visibility.Visible;
                    addComboBox.Visibility = Visibility.Visible;
                    buttonAdd.Visibility = Visibility.Visible;

                    labelAdd.Content = "City";
                    a = db.ExecuteQuery("SELECT city_id, city, country FROM city, country WHERE city.country_id = country.country_id");
                    s = new string[a.Table.Rows.Count];
                    foreignKeys = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreignKeys[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + ", " + a.Table.Rows[i].ItemArray[2].ToString();
                    }
                    addComboBox.ItemsSource = s;

                    break;
                case "City":
                    tables = "city";
                    fields = "city";
                    where = " city_id = 1";

                    labelAdd.Visibility = Visibility.Visible;
                    addComboBox.Visibility = Visibility.Visible;
                    buttonAdd.Visibility = Visibility.Visible;

                    labelAdd.Content = "Country";
                    a = db.ExecuteQuery("SELECT country_id, country FROM country");
                    s = new string[a.Table.Rows.Count];
                    foreignKeys = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreignKeys[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    addComboBox.ItemsSource = s;
                    break;
                case "Country":
                    tables = "country";
                    fields = "country";
                    where = " country_id = 1";

                    labelAdd.Visibility = Visibility.Hidden;
                    addComboBox.Visibility = Visibility.Hidden;
                    buttonAdd.Visibility = Visibility.Hidden;
                    break;
                default:
                    tables = "temp";
                    fields = "*";
                    break;
            }
        }

        void CreateFronXML()
        {
            for (int i = 0; i < db.xml.Tables.Count; i++)
                for (int j = 0; j < db.xml.Tables[i].Rows.Count; j++)
                {
                    string table = db.xml.Tables[i].TableName;

                    string fields = db.xml.Tables[i].Columns[0].ColumnName; 
                    for (int k = 1; k < db.xml.Tables[i].Columns.Count; k++)
                        fields += ", " + db.xml.Tables[i].Columns[k].ColumnName; 

                    string values = "'" + db.xml.Tables[i].Rows[j].ItemArray[0] + "'";
                    for (int k = 1; k < db.xml.Tables[i].Rows[j].ItemArray.Length; k++)
                        if (db.xml.Tables[i].Rows[j].ItemArray[k] == DBNull.Value || db.xml.Tables[i].Rows[j].ItemArray[k] == null)
                            values += ", null";
                        else if (db.xml.Tables[i].Columns[k].DataType == typeof(int))
                            values += ", " + db.xml.Tables[i].Rows[j].ItemArray[k];
                        else
                            values += ", '" + db.xml.Tables[i].Rows[j].ItemArray[k] + "'";

                    if (!db.CreateEntity(table, fields, values))
                    {
                        MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
        }

        private void tableSelectionComboBox_DropDownClosed(object sender, EventArgs e)
        {
            UpdateComboBoxes();

            System.Data.DataView data = db.LoadTable(fields, tables, where);
            if (data == null)
            {
                MessageBox.Show("This table is empty or does not have an item with id = 1. In such cases this function just won't work. Sorry.","Something terrible happend!", MessageBoxButton.OK, MessageBoxImage.Error);
                //TODO доп окно для обработки этого
            }

            //отчищаем загруженную строку
            data.Table.Rows[0].ItemArray = data.Table.Rows[0].ItemArray.Select(x => (x.GetType() == typeof(string)? "" : null) ).ToArray();
            newEntityDataGrid.ItemsSource = data;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            switch (tables)
            {
                case "painting":
                    s = "Artist";
                    break;
                case "exhibition":
                    s = "Address";
                    break;
                case "auction":
                    s = "Address";
                    break;
                case "address":
                    s = "City";
                    break;
                case "city":
                    s = "Country";
                    break;
            }
            CreateWindow w = new CreateWindow(db, s);
            w.ShowDialog();
            UpdateComboBoxes();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (newEntityDataGrid.Items.Count == 0)
                return;

            System.Data.DataRowView item = (System.Data.DataRowView)newEntityDataGrid.Items[0];
            string[] vals = item.Row.ItemArray.Select(x => (x == null || x == DBNull.Value) ? "null" : "'" + (string)x + "'" ).ToArray();

            string values = "";
            for (int i = 0; i < vals.Length - 1; i++)
                values += vals[i] + ", ";
            values += vals[vals.Length - 1];

            //for tables with foreing keys
            string s = GetFKFields(tables);
            if (s != "")
            {
                if (addComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Поле внешнего значения не заполнено!");
                    return;
                }

                fields += ", " + s;
                values += ", " + foreignKeys[addComboBox.SelectedIndex];
            }

            //XML
            if (!db.xml.Tables.Contains(tables))
            {
                db.xml.Tables.Add(item.DataView.ToTable(tables));
            }
            else
            {
                db.xml.Tables[tables].Rows.Add(item);
            }
            if (s != "")
            {
                db.xml.Tables[tables].Columns.Add(s, typeof(int));

                object[] a = new object[] { Convert.ToInt32(foreignKeys[addComboBox.SelectedIndex]) };
                db.xml.Tables[tables].Rows[ db.xml.Tables[tables].Rows.Count - 1 ].ItemArray = item.Row.ItemArray.Concat(a.AsEnumerable()).ToArray();
            }

            //run query
            if (!db.CreateEntity(tables, fields, values))
            {
                MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (main)
            {
                db.EndTransaction(true);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (main)
            {
                db.EndTransaction(false);
            }
            Close();
        }

        private void buttonXMLExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML|*.xml";
            string fname;
            if (saveFileDialog.ShowDialog() == true)
            {
                fname = saveFileDialog.FileName;
                db.xml.WriteXml(fname);
                db.xml.WriteXmlSchema(fname + "_shema.xml");
            }
        }

        private void buttonXMLImport_Click(object sender, RoutedEventArgs e)
        {
            db.xml = new System.Data.DataSet();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml";
            string fname;
            if (openFileDialog.ShowDialog() == true)
            {
                fname = openFileDialog.FileName;
                try
                {
                    db.xml.ReadXmlSchema(fname + "_shema.xml");
                }
                catch
                { }

                db.xml.ReadXml(fname);
                if (db.xml.DataSetName != "create")
                {
                    MessageBox.Show("Invalid data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    db.xml = new System.Data.DataSet();
                    return;
                }

                CreateFronXML();
            }
        }
    }
}
