using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DomainViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string domName = DomainName.Text;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection.Open();

            string query = "INSERT INTO Domains(Name) VALUES('" + domName + "')";

            using (SqlCommand myCommand = new SqlCommand(query, myConnection)) { 

            myCommand.ExecuteNonQuery();
            }

            string createouquery = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OUs' and xtype='U') CREATE TABLE [dbo].[OUs] (Id INT NOT NULL, Name VARCHAR(20) NOT NULL, PRIMARY KEY(Id))";

            using (SqlCommand myCommand = new SqlCommand(createouquery, myConnection))
            {

                myCommand.ExecuteNonQuery();
            }

            myConnection.Close();
        }
    }
}
