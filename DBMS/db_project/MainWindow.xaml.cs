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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace db_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        string[] ids;
        string tables;
        string fields;
        List<string> searchOptions;
        System.Data.DataView dataBuff;
        string[] idsBuff;

        public MainWindow()
        {
            InitializeComponent();
            Connect();
            //db.InitializeDefaultConnection();
        }

        void Connect()
        {
            ConnectionWindow w = new ConnectionWindow(db);
            w.ShowDialog();

            if (db.connection == null)
            {
                buttonCreateRelation.IsEnabled = buttonDeleteRelation.IsEnabled = false;
                buttonDelete.IsEnabled = buttonCreate.IsEnabled = buttonUpdate.IsEnabled = false;
                button.IsEnabled = false;
                tableSelectionComboBox.IsEnabled = false;
            }
            else
            {
                buttonCreateRelation.IsEnabled = buttonDeleteRelation.IsEnabled = true;
                buttonDelete.IsEnabled = buttonCreate.IsEnabled = buttonUpdate.IsEnabled = true;
                button.IsEnabled = true;
                tableSelectionComboBox.IsEnabled = true;
            }
        }

        void LoadTable()
        {
            tables = "";
            fields = "";
            string where = "";
            string order = "";
            searchOptions = new List<string>();

            switch (tableSelectionComboBox.Text)
            {
                case "Artists":
                    tables = "artist";
                    fields = "artist.artist_id as id, first_name, last_name";
                    where = "artist.artist_id IS NOT NULL";
                    order = "artist.artist_id";

                    searchOptions.Add("First name");
                    searchOptions.Add("Last name");

                    if (addCheckBox0.IsChecked.Value)
                    {
                        fields += ", internet_site.site, artist_site.username";
                        tables += ", artist_site, internet_site";
                        where = "artist.artist_id = artist_site.artist_id AND internet_site.site_id = artist_site.site_id";

                        searchOptions.Add("Site");
                        searchOptions.Add("Username");
                    }

                    break;
                case "Paintings":

                    fields = "painting.painting_id as id, artist.first_name as artist, artist.last_name, painting.title as name, painting.technique, painting.year";
                    tables = "painting, artist";
                    where = "artist.artist_id = painting.artist_id";
                    order = "painting_id";

                    searchOptions.Add("Artist first name");
                    searchOptions.Add("Artist last name");
                    searchOptions.Add("Painting name");
                    searchOptions.Add("Technique");
                    searchOptions.Add("Year");

                    break;
                case "Exhibitions":

                    tables = "exhibition";
                    fields = "exhibition.exhibition_id as id, exhibition_name as exhibition";
                    where = "exhibition.exhibition_id IS NOT NULL";
                    order = "exhibition.exhibition_id";

                    searchOptions.Add("Exhibition name");

                    if (addCheckBox0.IsChecked.Value)
                    {
                        fields += ", painting.title as painting";
                        tables += ", painting_exhibition, painting";
                        where += " AND exhibition.exhibition_id = painting_exhibition.exhibition_id AND painting.painting_id = painting_exhibition.painting_id";

                        searchOptions.Add("Painting name");
                    }
                    if (addCheckBox1.IsChecked.Value)
                    {
                        fields += ", address, city, country";
                        tables += ", address, city, country";
                        where += " AND exhibition.address_id = address.address_id AND address.city_id = city.city_id AND city.country_id = country.country_id";

                        searchOptions.Add("Address");
                        searchOptions.Add("City");
                        searchOptions.Add("Country");
                    }

                    break;
                case "Auctions":

                    tables = "auction";
                    fields = "auction.auction_id as id, auction_name as auction";
                    where = "auction.auction_id IS NOT NULL";
                    order = "auction.auction_id";

                    searchOptions.Add("Auction name");

                    if (addCheckBox0.IsChecked.Value)
                    {
                        fields += ", painting.title as painting";
                        tables += ", painting_auction, painting";
                        where += " AND auction.auction_id = painting_auction.auction_id AND painting.painting_id = painting_auction.painting_id";

                        searchOptions.Add("Painting name");
                    }
                    if (addCheckBox1.IsChecked.Value)
                    {
                        fields += ", address, city, country";
                        tables += ", address, city, country";
                        where += " AND auction.address_id = address.address_id AND address.city_id = city.city_id AND city.country_id = country.country_id";

                        searchOptions.Add("Address");
                        searchOptions.Add("City");
                        searchOptions.Add("Country");
                    }


                    break;
                case "Sites":

                    fields = "site_id as id, site";
                    tables = "internet_site";
                    where = "site_id IS NOT NULL";
                    order = "site_id";

                    searchOptions.Add("Site");

                    break;
                default:
                    return;
            }

            var data = db.LoadTable(fields, tables, where, order);

            ids = new string[data.Table.Rows.Count];
            for (int i = 0; i < ids.Length; i++)
                ids[i] = data.Table.Rows[i].ItemArray[0].ToString();
            
            data.Table.Columns.RemoveAt(0);
            dataGrid.ItemsSource = data;

            idsBuff = ids;
            dataBuff = data;    

            searchFieldComboBox.ItemsSource = searchOptions;
            Search();   //не очень хорошо оставлять это здесь(!!!)
        }

        void DeleteSelectedItem()
        {
            if (tables == null)
                return;

            //Начало транзакции
            db.BeginTransaction();

            string table = tables.Split(',')[0];
            string idField = fields.Split(' ')[0];
            int idIndex = dataGrid.SelectedIndex;

            if (idIndex == -1)
                return;

            MessageBoxResult r = MessageBox.Show("Are you sure you want to delete this item?","", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
                if (CheckCascade(table))
                    db.DeleteEntity(table, idField, ids[idIndex]);

            db.EndTransaction(true);    //? менять значение?
        }

        bool CheckCascade(string table)
        {
            int idIndex = dataGrid.SelectedIndex;
            string subquery;
            switch (table)
            {
                case "artist":

                    subquery = String.Format("SELECT painting_id FROM painting WHERE artist_id = {0};", ids[idIndex]);
                    var data = db.ExecuteQuery(subquery);
                    if (data.Table.Rows.Count > 0)
                    {
                        MessageBoxResult r = MessageBox.Show("All the artist's paintings will be deleted!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        if (r == MessageBoxResult.OK)
                        {
                            db.DeleteEntity("painting", "artist_id", ids[idIndex]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    db.DeleteEntity("artist_site", "artist_id", ids[idIndex]);
                    return true;

                case "painting":

                    db.DeleteEntity("painting_exhibition", "painting_id", ids[idIndex]);
                    db.DeleteEntity("painting_auction", "painting_id", ids[idIndex]);

                    return true;
                case "exhibition":

                    db.DeleteEntity("painting_exhibition", "exhibition_id", ids[idIndex]);
                    //TODO : удалять адрес, город, страну, и даже небо, даже Аллаха...

                    return true;
                case "auction":

                    db.DeleteEntity("painting_auction", "auction_id", ids[idIndex]);

                    return true;
                case "internet_site":

                    db.DeleteEntity("artist_site", "site_id", ids[idIndex]);

                    return true;
            }

            return false;
        }

        void UpdateSelectedItem()
        {
            if (tables == null)
                return;

            string table = tables.Split(',')[0];
            string idField = fields.Split(' ')[0];
            int idIndex = dataGrid.SelectedIndex;

            if (idIndex == -1)
                return;

            UpdateWindow w = new UpdateWindow(db, table, idField, ids[idIndex]);
            w.ShowDialog();

            LoadTable();
        }

        void Search()
        {
            if (searchFieldComboBox.SelectedIndex < 0)
                return;

            List<string> newIds = new List<string>();
            System.Data.DataView t = new System.Data.DataView(dataBuff.ToTable());

            int deleted = 0;
            for (int i = 0; i < dataBuff.Table.Rows.Count; i++)
            {
                if (exactMatchCheckBox.IsChecked.Value)
                {
                    if (dataBuff.Table.Rows[i].ItemArray[searchFieldComboBox.SelectedIndex].ToString() != searchTextBox.Text)
                    {
                        t.Table.Rows[i - deleted].Delete();
                        deleted++;
                        continue;
                    }
                }
                else
                {
                    if (!dataBuff.Table.Rows[i].ItemArray[searchFieldComboBox.SelectedIndex].ToString().Contains(searchTextBox.Text))
                    {
                        t.Table.Rows[i - deleted].Delete();
                        deleted++;
                        continue;
                    }
                }
                newIds.Add(idsBuff[i]);
            }

            ids = newIds.ToArray();
            dataGrid.ItemsSource = t;
        }

        void CancelSearch()
        {
            ids = idsBuff;
            dataGrid.ItemsSource = dataBuff;
        }

        private void tableSelectionComboBox_SelectionChanged(object sender, EventArgs e)
        {
            switch (tableSelectionComboBox.Text)
            {
                case "Artists":
                    addCheckBox0.Visibility = Visibility.Visible;
                    addCheckBox0.IsChecked = false;
                    addCheckBox0.Content = "Show sites";

                    addCheckBox1.Visibility = Visibility.Hidden;
                    break;
                case "Exhibitions":
                    addCheckBox0.Visibility = Visibility.Visible;
                    addCheckBox0.IsChecked = false;
                    addCheckBox0.Content = "Show paintings";

                    addCheckBox1.Visibility = Visibility.Visible;
                    addCheckBox1.IsChecked = false;
                    addCheckBox1.Content = "Show address";
                    break;
                case "Auctions":
                    addCheckBox0.Visibility = Visibility.Visible;
                    addCheckBox0.IsChecked = false;
                    addCheckBox0.Content = "Show paintings";

                    addCheckBox1.Visibility = Visibility.Visible;
                    addCheckBox1.IsChecked = false;
                    addCheckBox1.Content = "Show address";
                    break;
                default:
                    addCheckBox0.Visibility = Visibility.Hidden;
                    addCheckBox1.Visibility = Visibility.Hidden;
                    break;
            }
            LoadTable();
        }
        private void addCheckBox0_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }
        private void addCheckBox1_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow w = new CreateWindow(db);
            w.ShowDialog();
            LoadTable();
        }

        private void buttonCreateRelation_Click(object sender, RoutedEventArgs e)
        {
            CreateRelationWindow w = new CreateRelationWindow(db);
            w.Show();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItem();
            LoadTable();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedItem();
        }

        private void buttonDeleteRelation_Click(object sender, RoutedEventArgs e)
        {
            deleteRelationWindow w = new deleteRelationWindow(db);
            w.ShowDialog();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void buttonCancelSearch_Click(object sender, RoutedEventArgs e)
        {
            CancelSearch();
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text == "Search")
                searchTextBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string[] allTables = new string[] { "artist", "artist_site", "internet_site",
                                                "painting", "painting_exhibition", "exhibition",
                                                "painting_auction", "auction", "address", "city", "country"};
            System.Data.DataSet ds = new System.Data.DataSet("artist_database");
            for (int i = 0; i < allTables.Length; i++)
            {
                System.Data.DataTable t = db.LoadTable(allTables[i]).ToTable(allTables[i]);
                ds.Tables.Add(t);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML|*.xml";
            string fname;
            if (saveFileDialog.ShowDialog() == true)
            {
                fname = saveFileDialog.FileName;
                ds.WriteXml(fname);
                ds.WriteXmlSchema(fname + "_shema.xml");
            }
        }

        private void buttonRefreshConn_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }
    }
}
