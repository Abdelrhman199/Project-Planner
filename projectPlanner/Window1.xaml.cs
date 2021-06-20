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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       
        public Window1()
        {
            InitializeComponent();
        }
        public void insertManger(String name,String password)
        { 
             SqlConnection  connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "INSERT into projectManger (mangerName,password) values(@mangerName,@password)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("@mangerName", SqlDbType.VarChar);
            command.Parameters["@mangerName"].Value = name;
            command.Parameters.Add("@password", SqlDbType.VarChar);
            command.Parameters["@password"].Value = password;
           // MessageBox.Show(password);
            command.ExecuteNonQuery();
            
            connection.Close();




        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            insertManger(username.Text, password.Password.ToString());
            
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

       

        private void Password_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
