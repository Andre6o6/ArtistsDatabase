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
    /// <summary>
    /// Interaction logic for ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        Database db = null;

        public ConnectionWindow()
        {
            InitializeComponent();
        }

        public ConnectionWindow(Database db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (db.InitializeConnection(hostTextBox.Text, portTextBox.Text, userTextBox.Text, passwordBox.Password, databaseTextBox.Text))
            {
                MessageBox.Show("Connections successful!");
            }
            else
            {
                MessageBox.Show("Error occured while connecting! Check if server is running.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                db = null;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
