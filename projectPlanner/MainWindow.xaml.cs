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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projectPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public int mangerId;
        
        public MainWindow()
        {
           
           InitializeComponent();
            
        }

        public Boolean logIn(String name,String password)
        {
            
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "select mangerName,password from  projectManger where mangerName=@mangerName and password=@password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@mangerName", SqlDbType.VarChar);
            command.Parameters["@mangerName"].Value = name;
            command.Parameters.Add("@password", SqlDbType.VarChar);
            command.Parameters["@password"].Value = password;
            MessageBox.Show(password);
           
           if( command.ExecuteScalar()==null)
            {
                MessageBox.Show("Username or password is wrong");
                connection.Close();
                return false;
               
            }

            command.ExecuteNonQuery();
            connection.Close();
            getMangerId(name);

            return true;
            
        }
        public void getMangerId(String name)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "select mangerId from projectManger where mangerName=@mangerName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@mangerName", SqlDbType.VarChar);
            command.Parameters["@mangerName"].Value = name;
            mangerId = (int)command.ExecuteScalar();
           // MessageBox.Show(mangerId.ToString());
            connection.Close();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWin = new Window1();
            newWin.Show();

          this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (logIn(username.Text, password.Password.ToString()))
            {
                
                createProject newWindow = new createProject(mangerId);
                newWindow.Show();
                this.Close();
            }
        }
    }
    
}
