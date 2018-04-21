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
    public partial class deleteRelationWindow : Window
    {
        Database db = null;
        string[] fkeys1;
        string[] fkeys2;
        string fkeyField1 = "";
        string fkeyField2 = "";
        string table = "";
        //System.Data.DataSet xml = new System.Data.DataSet();

        public deleteRelationWindow()
        {
            InitializeComponent();
        }

        public deleteRelationWindow(Database db)
        {
            InitializeComponent();
            this.db = db;
            this.db.xml = new System.Data.DataSet("deleteRelations");
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
            switch (tableComboBox1.Text + tableComboBox2.Text)
            {
                case "ArtistSite":
                    table = "artist_site";
                    fkeyField1 = "artist_id";
                    fkeyField2 = "site_id";
                    labelAttr.Content = "Username";

                    a = db.ExecuteQuery("SELECT artist.artist_id, first_name, last_name, username, site, internet_site.site_id FROM artist, artist_site, internet_site WHERE artist.artist_id = artist_site.artist_id AND internet_site.site_id = artist_site.site_id");
                    s = new string[a.Table.Rows.Count];
                    fkeys1 = new string[s.Length];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys1[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        fkeys2[i] = a.Table.Rows[i].ItemArray[5].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + " " + a.Table.Rows[i].ItemArray[2].ToString() + " -- " + a.Table.Rows[i].ItemArray[3].ToString() + " -- " + a.Table.Rows[i].ItemArray[4].ToString();
                    }
                    itemComboBox.ItemsSource = s;

                    break;
                case "PaintingExhibition":
                    table = "painting_exhibition";
                    fkeyField1 = "painting_id";
                    fkeyField2 = "exhibition_id";
                    labelAttr.Content = "Original";

                    a = db.ExecuteQuery("SELECT painting.painting_id, title, is_original, exhibition_name, exhibition.exhibition_id FROM painting, painting_exhibition, exhibition WHERE painting.painting_id = painting_exhibition.painting_id AND painting_exhibition.exhibition_id = exhibition.exhibition_id");
                    s = new string[a.Table.Rows.Count];
                    fkeys1 = new string[s.Length];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys1[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        fkeys2[i] = a.Table.Rows[i].ItemArray[4].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + " -- " + a.Table.Rows[i].ItemArray[2].ToString() + " -- " + a.Table.Rows[i].ItemArray[3].ToString();
                    }
                    itemComboBox.ItemsSource = s;

                    break;
                case "PaintingAuction":
                    table = "painting_auction";
                    fkeyField1 = "painting_id";
                    fkeyField2 = "auction_id";
                    labelAttr.Content = "Starting price";

                    a = db.ExecuteQuery("SELECT painting.painting_id, title, starting_price, auction_name, auction.auction_id FROM painting, painting_auction, auction WHERE painting.painting_id = painting_auction.painting_id AND painting_auction.auction_id = auction.auction_id");
                    s = new string[a.Table.Rows.Count];
                    fkeys1 = new string[s.Length];
                    fkeys2 = new string[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        fkeys1[i] = a.Table.Rows[i].ItemArray[0].ToString();
                        fkeys2[i] = a.Table.Rows[i].ItemArray[4].ToString();
                        s[i] = a.Table.Rows[i].ItemArray[1].ToString() + " -- " + a.Table.Rows[i].ItemArray[2].ToString() + " -- " + a.Table.Rows[i].ItemArray[3].ToString();
                    }
                    itemComboBox.ItemsSource = s;

                    break;
            }
        }

        void DeleteItem()
        {
            if (table == "")
                return;

            int i = itemComboBox.SelectedIndex;

            string fkeyFields = fkeyField1 + ", " + fkeyField2;
            string fkeys = fkeys1[i] + ", " + fkeys2[i];

            

            //run query
            if (db.DeleteEntity(table, fkeyFields, fkeys))
            {
                //backup for xml export
                if (db.xml.Tables.Contains(table))
                {
                    db.xml.Tables[table].Rows.Add(Convert.ToInt32(fkeys1[i]), Convert.ToInt32(fkeys2[i]));
                }
                else
                {
                    db.xml.Tables.Add(table);
                    db.xml.Tables[table].Columns.Add(fkeyField1, typeof(int));
                    db.xml.Tables[table].Columns.Add(fkeyField2, typeof(int));
                    db.xml.Tables[table].Rows.Add(Convert.ToInt32(fkeys1[i]), Convert.ToInt32(fkeys2[i]));
                }
            }
            else
            {
                MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            labelDeletedCount.Content = Convert.ToInt32(labelDeletedCount.Content) + 1;
        }

        void DeleteFronXML()
        {
            int errorCount = 0;
            for (int i = 0; i < db.xml.Tables.Count; i++)
                for (int j = 0; j < db.xml.Tables[i].Rows.Count; j++)
                {
                    string table = db.xml.Tables[i].TableName;
                    string fkeyFields = db.xml.Tables[i].Columns[0].ColumnName + ", " + db.xml.Tables[i].Columns[1].ColumnName;
                    string fkeys = db.xml.Tables[i].Rows[j].ItemArray[0] + ", " + db.xml.Tables[i].Rows[j].ItemArray[1];

                    if (!db.DeleteEntity(table, fkeyFields, fkeys))
                    {
                        //MessageBox.Show("Error occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        errorCount++;
                        continue;
                    }

                    labelDeletedCount.Content = Convert.ToInt32(labelDeletedCount.Content) + 1;
                }

            if (errorCount > 0)
            {
                MessageBox.Show(errorCount + " error(s) occured!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tableComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            UpdateSecondComboBox();
        }

        private void tableComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
            LoadItems();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("All deleted items will be restored!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (r == MessageBoxResult.OK)
            {
                //откат транзакции
                db.EndTransaction(false);
                Close();
            }
            else
            {
                return;
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("You won't be able to restore deleted items after closing!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (r == MessageBoxResult.OK)
            {
                db.EndTransaction(true);
                Close();
            }
            else
            {
                return;
            }
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
                try {
                    db.xml.ReadXmlSchema(fname + "_shema.xml");
                }
                catch
                { }

                db.xml.ReadXml(fname);
                if (db.xml.DataSetName != "deleteRelations")
                {
                    MessageBox.Show("Invalid data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    db.xml = new System.Data.DataSet();
                    return;
                }

                DeleteFronXML();
            }
        }
    }
}
