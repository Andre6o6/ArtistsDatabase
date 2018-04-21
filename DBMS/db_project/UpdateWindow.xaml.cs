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

namespace db_project
{
    public partial class UpdateWindow : Window
    {
        Database db;
        string table;
        string fields;
        string idField;
        string id;
        string fFieldName = "";
        string[] fkeys;
        string[] fvalues;
        System.Data.DataView data = null;   //entity data

        public UpdateWindow()
        {
            InitializeComponent();
        }

        public UpdateWindow(Database db, string table, string idField, string id)
        {
            InitializeComponent();
            this.db = db;
            this.table = table;
            this.idField = idField;
            this.id = id;

            labelTable.Content = table;

            LoadEntity();
        }

        void LoadEntity()
        {
            switch (table)
            {
                case "artist":
                    fields = "first_name, last_name";
                    fFieldComboBox.Visibility = Visibility.Hidden;
                    break;
                case "painting":
                    fields = "title, technique, year";
                    break;
                case "exhibition":
                    fields = "exhibition_name";
                    break;
                case "auction":
                    fields = "auction_name";
                    break;
                case "internet_site":
                    fields = "site";
                    break;
            }
            data = db.LoadTable(fields, table, idField + " = " + id) ;
            
            dataGrid.ItemsSource = data;

            System.Data.DataView foreignData;
            string fId;
            switch (table)
            {
                case "painting":
                    labelFField.Content = "Author";

                    fFieldName = "artist_id";

                    //get fkey for updating entity
                    foreignData = db.ExecuteQuery(String.Format("SELECT artist_id FROM painting WHERE {0} = {1}", idField, id));
                    fId = foreignData.Table.Rows[0].ItemArray[0].ToString();

                    //load combobox values and corresponding fkeys
                    foreignData = db.ExecuteQuery("SELECT artist_id, first_name, last_name FROM artist");
                    fvalues = new string[foreignData.Table.Rows.Count];
                    fkeys = new string[fvalues.Length];
                    for (int i = 0; i < fvalues.Length; i++)
                    {
                        fkeys[i] = foreignData.Table.Rows[i].ItemArray[0].ToString();
                        fvalues[i] = foreignData.Table.Rows[i].ItemArray[1].ToString() + " " + foreignData.Table.Rows[i].ItemArray[2].ToString();

                        if (fkeys[i] == fId)
                            fFieldComboBox.SelectedItem = fvalues[i];    //set foreign value of updating entity
                    }

                    fFieldComboBox.ItemsSource = fvalues;

                    break;
                case "auction":
                case "exhibition":
                    labelFField.Content = "Address";

                    fFieldName = "address_id";

                    //get fkey for updating entity
                    foreignData = db.ExecuteQuery(String.Format("SELECT address_id FROM {0} WHERE {1} = {2}", table, idField, id));
                    fId = foreignData.Table.Rows[0].ItemArray[0].ToString();

                    //load combobox values and corresponding fkeys
                    foreignData = db.ExecuteQuery("SELECT address.address_id, address, city, country FROM address, city, country WHERE address.city_id = city.city_id AND city.country_id = country.country_id");
                    fvalues = new string[foreignData.Table.Rows.Count];
                    fkeys = new string[fvalues.Length];
                    for (int i = 0; i < fvalues.Length; i++)
                    {
                        fkeys[i] = foreignData.Table.Rows[i].ItemArray[0].ToString();
                        fvalues[i] = foreignData.Table.Rows[i].ItemArray[1].ToString() + ", " + foreignData.Table.Rows[i].ItemArray[2].ToString() + ", " + foreignData.Table.Rows[i].ItemArray[3].ToString();

                        if (fkeys[i] == fId)
                            fFieldComboBox.SelectedItem = fvalues[i];    //set foreign value of updating entity
                    }

                    fFieldComboBox.ItemsSource = fvalues;
                    break;
            }
            
        }

        bool CommitUpdates()
        {
            var items = data.Table.Rows[0].ItemArray;

            string fieldsValues = "'" + items[0].ToString() + "'";
            for (int i = 1; i < items.Count(); i++)
                fieldsValues += ", '" + items[i].ToString() + "'";

            //если у таблицы есть fkey, записывается его значение
            if (fFieldName != "") {
                fields += ", " + fFieldName;
                fieldsValues += ", " + fkeys[fFieldComboBox.SelectedIndex];
            }

            if (data.Table.GetChanges() == null)
            {
                MessageBox.Show("Error occured or no changes were made!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!db.UpdateEntity(table, fields, fieldsValues, idField, id))
            {
                MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }           

            return true;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (CommitUpdates())
                Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
