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
    /// Interaction logic for configureProject.xaml
    /// </summary>
    public partial class configureProject : Window
    {
        public int projectID;
        public configureProject()
        {
            InitializeComponent();
        }
        public configureProject(int projectId)
        {
            InitializeComponent();
            projectID = projectId;

        }
        public void insertTask(String name, String duration , String startdate, String enddate,int pId)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            
            String query = "INSERT into Task (taskName,noDays,startDate , dueDate,projectId) values(@taskName,@noDays, @startDate , @dueDate,@projectId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@taskName", SqlDbType.VarChar);
            command.Parameters["@taskName"].Value = name;
            command.Parameters.Add("@noDays", SqlDbType.Int);
            command.Parameters["@noDays"].Value = duration;
            command.Parameters.Add("@startDate", SqlDbType.Date);
            command.Parameters["@startDate"].Value =taskStartDate.Value;
            command.Parameters.Add("@dueDate", SqlDbType.Date);
            command.Parameters["@dueDate"].Value = taskEndDate.Value;
            command.Parameters.Add("@projectId", SqlDbType.Int);
            command.Parameters["@projectId"].Value = pId;


            command.ExecuteNonQuery();

            connection.Close();
            taskGrid.ItemsSource = null;
            //taskGrid.ItemsSource =;*/x
            filldatagrid(taskGrid);
            







        }
        private void filldatagrid(DataGrid data)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            con.Open();
            string sqlquery = "select * from task";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            data.ItemsSource = dt.DefaultView;
            con.Close();
        }

        public Boolean validateInput()
        {
            // start later than end date
            if (DateTime.Compare(Convert.ToDateTime(taskStartDate.Value), Convert.ToDateTime(taskEndDate.Value)) > 0)
            {
                MessageBox.Show("Invalid Start or End Dates");
                taskName.Clear();
                taskDuration.Clear();
                return false;
            }
            else if(DateTime.Compare((Convert.ToDateTime(taskStartDate.Value).AddDays(int.Parse(taskDuration.Text))), Convert.ToDateTime(taskEndDate.Value)) < 0)
            {
                return true;
            }
            else if (DateTime.Compare((Convert.ToDateTime(taskStartDate.Value).AddDays(int.Parse(taskDuration.Text))), Convert.ToDateTime(taskEndDate.Value)) != 0  )
            {
                MessageBox.Show("Task Durantion later than the Task End Date");
                taskName.Clear();
                taskDuration.Clear();
                return false;
            }
            return true;
        }
        public void insertSubTask(String taskId)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "select taskId from task where taskName=@taskname";
            SqlCommand command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@taskname", SqlDbType.VarChar);
            command.Parameters["@taskname"].Value =taskName.Text ;
            
            int subtask_Id =(int)command.ExecuteScalar();
            MessageBox.Show("subtask ID" + subtask_Id.ToString());
          
            connection.Close();

             connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
             query = "insert into taskSubtasks (parentTaskId,subTaskId) values (@parentTaskId,@subTaskId)";
             command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@parentTaskId", SqlDbType.Int);
            command.Parameters["@parentTaskId"].Value = int.Parse(taskId);
            command.Parameters.Add("@subTaskId", SqlDbType.Int);
            command.Parameters["@subtaskId"].Value = subtask_Id;
            command.ExecuteNonQuery();
            connection.Close();


        }
        public void insertPredecessor(String taskId)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "select taskId from task where taskName=@taskname";
            SqlCommand command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@taskname", SqlDbType.VarChar);
            command.Parameters["@taskname"].Value = taskName.Text;

            int task_Id = (int)command.ExecuteScalar();
            MessageBox.Show("task ID " + task_Id.ToString());

            connection.Close();

            connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            query = "insert into taskPredecessors (taskId,PredecessorId) values (@taskId,@PredecessorId)";
            command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@PredecessorId", SqlDbType.Int);
            command.Parameters["@PredecessorId"].Value = int.Parse(taskId);
            command.Parameters.Add("@taskId", SqlDbType.Int);
            command.Parameters["@taskId"].Value = task_Id;
            command.ExecuteNonQuery();
            connection.Close();


        }
        public bool validateSubtask()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = " select noDays , sum(noDays) from task where  taskId in ( select subTaskId from taskSubtasks where parentTaskId=@parentId) GROUP BY noDays  ";
            SqlCommand command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@parentId", SqlDbType.Int);
            command.Parameters["@parentId"].Value = int.Parse(parentId_box.Text);
            object myObject = command.ExecuteScalar();
            connection.Close();
            int noDays=0;
            if (myObject!= null)
            {  noDays = (int)myObject;
                MessageBox.Show(noDays.ToString());
                if (noDays >= int.Parse(taskDuration.Text))
                {
                    return true;
                }
                return false;
            }
            else if(myObject==null)
            {
                return true;
            }
            return false;

           

          
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            projectPlanner.projectPlannerDataSet projectPlannerDataSet = ((projectPlanner.projectPlannerDataSet)(this.FindResource("projectPlannerDataSet")));
            // Load data into the table teamMembers. You can modify this code as needed.
            projectPlanner.projectPlannerDataSetTableAdapters.teamMembersTableAdapter projectPlannerDataSetteamMembersTableAdapter = new projectPlanner.projectPlannerDataSetTableAdapters.teamMembersTableAdapter();
            projectPlannerDataSetteamMembersTableAdapter.Fill(projectPlannerDataSet.teamMembers);
            System.Windows.Data.CollectionViewSource teamMembersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("teamMembersViewSource")));
            teamMembersViewSource.View.MoveCurrentToFirst();
            // Load data into the table task. You can modify this code as needed.
            projectPlanner.projectPlannerDataSetTableAdapters.taskTableAdapter projectPlannerDataSettaskTableAdapter = new projectPlanner.projectPlannerDataSetTableAdapters.taskTableAdapter();
            projectPlannerDataSettaskTableAdapter.Fill(projectPlannerDataSet.task);
            System.Windows.Data.CollectionViewSource taskViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("taskViewSource")));
            taskViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
              
                if (isSubTask.IsChecked == true && isPredessecor.IsChecked==false)
                {


                   // MessageBox.Show("enter0");
                   if( validateSubtask())
                    {
                      //  MessageBox.Show("enter");
                        insertTask(taskName.Text, taskDuration.Text, taskStartDate.Value.ToString(), taskEndDate.Value.ToString(),projectID);
                        insertSubTask(parentId_box.Text);
                        MessageBox.Show("new Task Added");

                    }
                    else { MessageBox.Show(" Invalid Subtask"); }



                }
                
                 else if (isSubTask.IsChecked == false && isPredessecor.IsChecked == true)
                    {
                        insertTask(taskName.Text, taskDuration.Text, taskStartDate.Value.ToString(), taskEndDate.Value.ToString(), projectID);
                        insertPredecessor(parentId_box.Text);
                    MessageBox.Show("new Task Added");

                }
                else if(isPredessecor.IsChecked==false && isSubTask.IsChecked==false)
                {
                    insertTask(taskName.Text, taskDuration.Text, taskStartDate.Value.ToString(), taskEndDate.Value.ToString(), projectID);
                     MessageBox.Show("new Task Added");

                }
                else
                {
                    MessageBox.Show("Choose One option");
                }
             
            }
            else
            {
                MessageBox.Show("Invalid start or end dates");
            }
                
                

      }

        private void IsPredessecor_Checked(object sender, RoutedEventArgs e)
        {
            if (isPredessecor.IsChecked == true)
            {
                taskName.Visibility = Visibility.Hidden;
                taskDuration.Visibility = Visibility.Hidden;
                taskStartDate.Visibility = Visibility.Hidden;
                taskEndDate.Visibility = Visibility.Hidden;
                parentId_box.Visibility = Visibility.Visible;
                parentId_label.Visibility = Visibility.Visible;
                nameS.Visibility = Visibility.Hidden;
                duratiobS.Visibility = Visibility.Hidden;
                startS.Visibility = Visibility.Hidden;
                endS.Visibility = Visibility.Hidden;



            }
            else
            {

                taskName.Visibility = Visibility.Visible;
                taskDuration.Visibility = Visibility.Visible;
                taskStartDate.Visibility = Visibility.Visible;
                taskEndDate.Visibility = Visibility.Visible;
                parentId_box.Visibility = Visibility.Visible;
                parentId_label.Visibility = Visibility.Visible;
                nameS.Visibility = Visibility.Visible;
                duratiobS.Visibility = Visibility.Visible;
                startS.Visibility = Visibility.Visible;
                endS.Visibility = Visibility.Visible;
                parentId_box.Visibility = Visibility.Hidden;
                parentId_label.Visibility = Visibility.Hidden;
            }
        }
    

    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            assign_taskId.Visibility = Visibility.Visible;
            assign_taskid_box.Visibility = Visibility.Visible;
            assign_memberId.Visibility = Visibility.Visible;
            assign_memberId_box.Visibility = Visibility.Visible;
            assign_save_box.Visibility = Visibility.Visible;
            Addmember_button.Visibility = Visibility.Hidden;
            assigen_hr_button.Visibility = Visibility.Hidden;
            titleM.Visibility = Visibility.Hidden;
            hoursPerDayM.Visibility = Visibility.Hidden;


        }
        public void insertHumanResources(string title,int hrsPerDay)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "insert into teamMembers (title,hoursPerDay) values (@title,@hoursPerDay)";
            SqlCommand command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@title", SqlDbType.VarChar);
            command.Parameters["@title"].Value = titleM.Text;
            command.Parameters.Add("@hoursPerDay", SqlDbType.Int);
            command.Parameters["@hoursPerDay"].Value = hrsPerDay;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void assignHR(string taskId, string memberId)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            connection.Open();
            String query = "update teamMembers set taskId=@taskId where memberId=@memberId";
            SqlCommand command = new SqlCommand(query, connection);
            // MessageBox.Show(startDate.Value);
            command.Parameters.Add("@taskId", SqlDbType.Int);
            command.Parameters["@taskId"].Value = int.Parse(taskId);
            command.Parameters.Add("@memberId", SqlDbType.Int);
            command.Parameters["@memberId"].Value =int.Parse(memberId);
            command.ExecuteNonQuery();
            connection.Close();
            

        }
        private void filldatagrid_teamMembers(DataGrid data)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-85QS9MQ;Initial Catalog=projectPlanner;Integrated Security=True");
            con.Open();
            string sqlquery = "select * from teamMembers";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            data.ItemsSource = dt.DefaultView;
            con.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            insertHumanResources(titleM.Text, int.Parse(hoursPerDayM.Text));
            taskGridmember.ItemsSource = null;
            filldatagrid_teamMembers(taskGridmember);
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Assign_save_box_Click(object sender, RoutedEventArgs e)
        {
            assignHR(assign_taskid_box.Text, assign_memberId_box.Text);
            assign_memberId_box.Clear();
            assign_taskid_box.Clear();
        }

        private void IsSubTask_Checked(object sender, RoutedEventArgs e)
        {
           
            
            if (isSubTask.IsChecked==true)
            {
                taskName.Visibility = Visibility.Hidden;
                taskDuration.Visibility = Visibility.Hidden;
                taskStartDate.Visibility = Visibility.Hidden;
                taskEndDate.Visibility = Visibility.Hidden;
                parentId_box.Visibility = Visibility.Visible;
                parentId_label.Visibility = Visibility.Visible;
                nameS.Visibility = Visibility.Hidden;
                duratiobS.Visibility = Visibility.Hidden;
                startS.Visibility = Visibility.Hidden;
                endS.Visibility = Visibility.Hidden;
                
                
                
            }
            else
            {
               
                taskName.Visibility = Visibility.Visible;
                taskDuration.Visibility = Visibility.Visible;
                taskStartDate.Visibility = Visibility.Visible;
                taskEndDate.Visibility = Visibility.Visible;
                parentId_box.Visibility = Visibility.Visible;
                parentId_label.Visibility = Visibility.Visible;
                nameS.Visibility = Visibility.Visible;
                duratiobS.Visibility = Visibility.Visible;
                startS.Visibility = Visibility.Visible;
                endS.Visibility = Visibility.Visible;
                parentId_box.Visibility = Visibility.Hidden;
                parentId_label.Visibility = Visibility.Hidden;

                
            }
        }
    }
}
