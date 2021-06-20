using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace projectPlanner
{
    /// <summary>
    /// Interaction logic for teamMembers.xaml
    /// </summary>
    public partial class teamMembers : Window
    {
        public teamMembers()
        {
            InitializeComponent();
        }
        public void insertMember(String title, int hoursPerDay)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "INSERT into teamMembers (title,hoursPerDay) values(@title,@hoursPerDay)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@title", SqlDbType.VarChar);
            command.Parameters["@title"].Value = title;
            command.Parameters.Add("@hoursPerDay", SqlDbType.Int);
            command.Parameters["@hoursPerDay"].Value = hoursPerDay;
          
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("A new member is added");



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            insertMember(title.Text,  int.Parse(hoursPerDay.Text));
            title.Clear();
            hoursPerDay.Clear();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            createProject win = new createProject();
            win.Show();
            this.Close();
        }
    }
}
