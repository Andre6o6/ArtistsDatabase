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
    public partial class CreateRelationWindow : Window
    {
        Database db = null;
        string[] fkeys1;
        string[] fkeys2;
        //System.Data.DataSet xml = new System.Data.DataSet();

        public CreateRelationWindow()
        {
            InitializeComponent();
        }

        public CreateRelationWindow(Database db)
        {
            InitializeComponent();
            this.db = db;
            this.db.xml = new System.Data.DataSet("createRelations");
            db.BeginTransaction();
        }

        void UpdateSecondComboBox()
        {
            string[] s;
            switch (tableComboBox1.Text)
            {
                case "Artist":
                    tableComboBox2.IsEnabled = true;
                    s = new string[] { "Site" };
                    tableComboBox2.ItemsSource = s;
                    break;
                case "Painting":
                    tableComboBox2.IsEnabled = true;
                    s = new string[] { "Exhibition", "Auction" };
                    tableComboBox2.ItemsSource = s;
                    break;
                default:
                    tableComboBox2.IsEnabled = false;
                    break;
            }
        }

        void LoadItems()
        {
            System.Data.DataView a;
            string[] s;
            switch (tableComboBox1.Text)
            {
                case "Artist":

                    a = db.ExecuteQuery("SELECT artist_id, first_name, last_name FROM artist");
                    s = new string[a.Table.Rows.Count];
                    fkeys1 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys1[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + " " + a.Table.Rows[i].ItemArray[2].ToString();
                    }
                    itemComboBox1.ItemsSource = s;

                    break;
                case "Painting":

                    a = db.ExecuteQuery("SELECT painting_id, title FROM painting");
                    s = new string[a.Table.Rows.Count];
                    fkeys1 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys1[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() ;
                    }
                    itemComboBox1.ItemsSource = s;

                    break;
            }
        }

        void LoadItems2()
        {
            System.Data.DataView a;
            string[] s;
            switch (tableComboBox2.Text)
            {
                case "Site":

                    attributeTextBox.Visibility = Visibility.Visible;
                    attributeCheckBox.Visibility = Visibility.Hidden;
                    attributeTextBox.Text = "";
                    labelAttribute.Content = "Username";

                    a = db.ExecuteQuery("SELECT site_id, site FROM internet_site");
                    s = new string[a.Table.Rows.Count];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys2[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    itemComboBox2.ItemsSource = s;

                    break;
                case "Exhibition":

                    attributeTextBox.Visibility = Visibility.Hidden;
                    attributeCheckBox.Visibility = Visibility.Visible;

                    labelAttribute.Content = " ";

                    a = db.ExecuteQuery("SELECT exhibition_id, exhibition_name FROM exhibition");
                    s = new string[a.Table.Rows.Count];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys2[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    itemComboBox2.ItemsSource = s;

                    break;
                case "Auction":

                    attributeTextBox.Visibility = Visibility.Visible;
                    attributeCheckBox.Visibility = Visibility.Hidden;
                    attributeTextBox.Text = "";
                    labelAttribute.Content = "Starting price";

                    a = db.ExecuteQuery("SELECT auction_id, auction_name FROM auction");
                    s = new string[a.Table.Rows.Count];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys2[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString();
                    }
                    itemComboBox2.ItemsSource = s;

                    break;
            }
        }

        bool CheckExisting(string table, string fields)
        {
            string ids = fields.Substring(0, fields.LastIndexOf(','));
            string idValues = fkeys1[itemComboBox1.SelectedIndex] + ", " + fkeys2[itemComboBox2.SelectedIndex];
            string where = string.Format("({0}) = ({1})", ids, idValues);
            var data = db.LoadTable(fields, table, where, ids);
            if (data == null)
                return false;                            
            return data.Table.Rows.Count > 0;
        }

        bool CheckExisting(string table, string fields, string values)
        {
            string where = string.Format("({0}) = ({1})", fields, values);
            var data = db.LoadTable(fields, table, where);
            if (data == null)
            {
                return false;
            }
            return data.Table.Rows.Count > 0;
        }

        void CreateFronXML()
        {
            List<string> existanceCol = new List<string>();
            int errorCount = 0;

            for (int i = 0; i < db.xml.Tables.Count; i++)
                for (int j = 0; j < db.xml.Tables[i].Rows.Count; j++)
                {
                    string table = db.xml.Tables[i].TableName;
                    string fields = db.xml.Tables[i].Columns[0].ColumnName + ", " + db.xml.Tables[i].Columns[1].ColumnName;
                    string values = db.xml.Tables[i].Rows[j].ItemArray[0] + ", " + db.xml.Tables[i].Rows[j].ItemArray[1];

                    //проверка на то, что такое отношение уже есть в таблице
                    if (CheckExisting(table, fields, values))
                    {
                        //MessageBox.Show("Relation already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        existanceCol.Add("(" + fields + ") = (" + values + ")");
                        errorCount++;
                        continue;
                    }

                    //если аттрибут не null, добавляем его
                    if (db.xml.Tables[i].Rows[j].ItemArray.Length == 3)
                    {
                        fields += ", " + db.xml.Tables[i].Columns[2].ColumnName;
                        //! проблемы с ковычками
                        values += (db.xml.Tables[i].Rows[j].ItemArray[2] != DBNull.Value) ? ", " + db.xml.Tables[i].Rows[j].ItemArray[2] : ", null";
                    }

                    //отправка запроса
                    if (db.CreateEntity(table, fields, values))
                    {
                        labelAddedCount.Content = Convert.ToInt32(labelAddedCount.Content) + 1;
                    }
                    else
                    {
                        //MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        errorCount++;
                    }
                }
            if (existanceCol.Count > 0)
            {
                string log = "";
                for (int i = 0; i < existanceCol.Count; i++)
                    log += existanceCol[i] + "\n";
                MessageBox.Show("Relations :\n" + log + "already exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (errorCount > 0)
            {
                MessageBox.Show(errorCount + " error(s) occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string table = "";
            string fields = "";
            string values = "";
            string s;
            switch (tableComboBox1.Text + tableComboBox2.Text)
            {
                case "ArtistSite":
                    table = "artist_site";
                    fields = "artist_id, site_id, username";
                    s = (attributeTextBox.Text == "") ? "null" : "'" + attributeTextBox.Text + "'";
                    values = fkeys1[itemComboBox1.SelectedIndex] + ", " + fkeys2[itemComboBox2.SelectedIndex] + ", " + s;
                    break;
                case "PaintingExhibition":
                    table = "painting_exhibition";
                    fields = "painting_id, exhibition_id, is_original";
                    int original = (attributeCheckBox.IsChecked.Value) ? 1 : 0;
                    values = fkeys1[itemComboBox1.SelectedIndex] + ", " + fkeys2[itemComboBox2.SelectedIndex] + ", " + original;
                    break;
                case "PaintingAuction":
                    table = "painting_auction";
                    fields = "painting_id, auction_id, starting_price";
                    s = (attributeTextBox.Text == "") ? "null" : attributeTextBox.Text;

                    if (attributeTextBox.Text == "")
                    {
                        MessageBox.Show("Price should be set!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        attributeTextBox.Focus();
                        return;
                    }
                    if (!attributeTextBox.Text.IsNumber())
                    {
                        MessageBox.Show("Price should be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        attributeTextBox.Focus();
                        attributeTextBox.SelectAll();
                        return;
                    }
                    values = fkeys1[itemComboBox1.SelectedIndex] + ", " + fkeys2[itemComboBox2.SelectedIndex] + ", " + s;
                    break;
                default:
                    return;
            }

            //проверка на то, что такое отношение уже есть в таблице
            if (CheckExisting(table, fields))
            {
                MessageBox.Show("Relation already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //отправка запроса
            if (db.CreateEntity(table, fields, values))
            {
                MessageBox.Show("Relation added.");
                labelAddedCount.Content = Convert.ToInt32(labelAddedCount.Content) + 1;

                //backup for xml export
                string fieldOrder = fields;
                if (values.Contains("null"))
                {
                    values = values.Substring(0, values.LastIndexOf(','));
                    fields = fields.Substring(0, fields.LastIndexOf(','));
                }
                var t = db.LoadTable(fieldOrder, table, "(" + fields + ") = (" + values + ")").ToTable(table);
                if (db.xml.Tables.Contains(table))
                {
                    db.xml.Tables[table].Rows.Add(t.Rows[0].ItemArray);
                }
                else
                {
                    db.xml.Tables.Add(t);
                }
            }
            else {
                MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void tableComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            UpdateSecondComboBox();
            itemComboBox2.ItemsSource = null;
            attributeTextBox.Visibility = Visibility.Hidden;
            attributeCheckBox.Visibility = Visibility.Hidden;
            labelAttribute.Content = "";
            LoadItems();
        }

        private void tableComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            LoadItems2();
        }

        private void buttonNew1_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow w = new CreateWindow(db, tableComboBox1.Text);
            w.ShowDialog();
            LoadItems();
        }

        private void buttonNew2_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow w = new CreateWindow(db, tableComboBox2.Text);
            w.ShowDialog();
            LoadItems2();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            db.EndTransaction(false);
            Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            db.EndTransaction(true);
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
                if (db.xml.DataSetName != "createRelations")
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
