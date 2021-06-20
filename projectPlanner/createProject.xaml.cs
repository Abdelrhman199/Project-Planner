using Syncfusion.Windows.Shared;
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
    /// Interaction logic for createProject.xaml
    /// </summary>
    public partial class createProject : Window
    {   public int id;
        public createProject()
        {
            InitializeComponent();
           
        }
        public createProject(int id)
        {
             InitializeComponent();
            this.id = id;
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }


        public Boolean validateInput()
        {
            // start later than end date
            if (DateTime.Compare(Convert.ToDateTime(startDate.Value), Convert.ToDateTime(dueDate.Value)) > 0)
            {
                MessageBox.Show("Invalid Start or End Dates");
                projectName.Clear();
                projectCost.Clear();
                return false;
            }
           
           
            return true;
        }
        public int getProjectID(string projectName)
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "select projectId from project where projectName=@projectName ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@projectName", SqlDbType.VarChar);
            command.Parameters["@projectName"].Value = projectName;
            int projectId = (int)command.ExecuteScalar();
            MessageBox.Show(projectId.ToString() + "project ID " );
            connection.Close();
            return projectId;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
                MainWindow obj = new MainWindow();
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
                connection.Open();
                String query = "insert into project (projectCost,pmID,startDate,dueDate,projectName) values (@projectCost,@pmID,@startDate,@dueDate,@projectName)";
                SqlCommand command = new SqlCommand(query, connection);
                // MessageBox.Show(startDate.Value);
                command.Parameters.Add("@projectCost", SqlDbType.Int);
                command.Parameters["@projectCost"].Value = int.Parse(projectCost.Text);
                command.Parameters.Add("@pmID", SqlDbType.Int);
                command.Parameters["@pmID"].Value = id;
                command.Parameters.Add("@startDate", SqlDbType.Date);
                /* DateTime result;
                 DateTime.TryParse(projectStartDate.Text, out result);
                 if(!result.Equals(DateTime.MinValue))
                 {
                     command.Parameters["@startDate"].Value=result;
                 }*/
                command.Parameters["@startDate"].Value = startDate.Value;
                command.Parameters.Add("@dueDate", SqlDbType.Date);
                command.Parameters["@dueDate"].Value = startDate.Value;
                command.Parameters.Add("@projectName", SqlDbType.VarChar);
                command.Parameters["@projectName"].Value = projectName.Text;


                command.ExecuteNonQuery();





               connection.Close();


                GridProject.ItemsSource = null;
                filldatagrid(GridProject);
            
            }
           
            
        }
        private void filldatagrid(DataGrid data)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            con.Open();
            string sqlquery = "select * from project";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            data.ItemsSource = dt.DefaultView;
            con.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            projectPlanner.projectPlannerDataSet projectPlannerDataSet = ((projectPlanner.projectPlannerDataSet)(this.FindResource("projectPlannerDataSet")));
            // Load data into the table project. You can modify this code as needed.
            projectPlanner.projectPlannerDataSetTableAdapters.projectTableAdapter projectPlannerDataSetprojectTableAdapter = new projectPlanner.projectPlannerDataSetTableAdapters.projectTableAdapter();
            projectPlannerDataSetprojectTableAdapter.Fill(projectPlannerDataSet.project);
            System.Windows.Data.CollectionViewSource projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            projectViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            configureProject newWin = new configureProject(getProjectID(projectName.Text));
            newWin.Show();
            this.Close();
        }
    }
}
