using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using EmployeeDatabaseCRUD.Models;

namespace EmployeeDatabase
{
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        Employees employees = new Employees();
        EmployeesRepository employeesR = new EmployeesRepository();
        public MainWindow()
        {
            InitializeComponent();
            WindowLoaded();
        }

        private void WindowLoaded()
        {
            //DataTable dataTable = employeesR.GetAll();
            //if (dataTable.Rows.Count > 0)
            //{
            //    noRecord.Visibility = Visibility.Hidden;
            //    displayData.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    noRecord.Visibility = Visibility.Visible;
            //    displayData.Visibility = Visibility.Hidden;
            //}

            //displayData.ItemsSource = dataTable.AsDataView();
        //    //client.BaseAddress = new Uri("http://localhost:60792"); 22392
        //    client.BaseAddress = new Uri("http://localhost:35518");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    this.Loaded += MainWindow_Loaded;
        //}

        //async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    HttpResponseMessage response = await client.GetAsync("/api/employees");
        //    //response.EnsureSuccessStatusCode(); // Throw on error code.
        //    var employees = await response.Content.ReadAsAsync<IEnumerable<Employees>>();
            //displayData.ItemsSource = employees;
        }

        //Add records into table
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            //var person = new Employees()
            //{
            //   ID = Int32.Parse(textID.Text),
            //    Name = textName.Text,
            //    Age = Int32.Parse(textAge.Text),
            //    Gender = textGender.Text,
            //    Address = textAddress.Text,
            //    Email = textEmail.Text
            //};
            //var response = await client.PostAsJsonAsync("/api/employees/", person);
            //response.EnsureSuccessStatusCode(); // Throw on error code.
            //MessageBox.Show("Student Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            //studentsListView.ItemsSource = await GetAllStudents();
            //studentsListView.ScrollIntoView(studentsListView.ItemContainerGenerator.Items[studentsListView.Items.Count - 1]);
            if (textID.IsEnabled)
            {
                bool status = employeesR.Add(employees);
                //bool status = employeesR.Add(Int32.Parse(textID.Text),
                //textName.Text,
                //Int32.Parse(textAge.Text),
                //listGender.Text,
                //textAddress.Text,
                //textEmail.Text);
                WindowLoaded();
                if (status)
                {
                    MessageBox.Show("Details of Employee " + textName.Text + " added Successfully");
                }
                ClearAll();
            } else
            {
                bool status = employeesR.Update(employees);
                //bool status = employees.Edit(Int32.Parse(textID.Text),
                //    textName.Text,
                //    Int32.Parse(textAge.Text),
                //    listGender.Text,
                //    textAddress.Text);
                if (status)
                {
                    MessageBox.Show("Details of Employee " + textID.Text + " updated Successfully");
                }
                WindowLoaded();
                ClearAll();
            }
        }

        private void ClearAll()
        {
            textID.Text = "";
            textName.Text = "";
            textAge.Text = "";
            listGender.SelectedIndex = 0;
            textAddress.Text = "";
            textEmail.Text = "";
            AddButton.Content = "Add";
            textID.IsEnabled = true;
            textEmail.IsEnabled = true;
        }

        //Edit selected record
        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (displayData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)displayData.SelectedItems[0];
                textID.Text = row["ID"].ToString();
                textName.Text = row["Name"].ToString();
                textAge.Text = row["Age"].ToString();
                listGender.Text = row["Gender"].ToString();
                textAddress.Text = row["Address"].ToString();
                textEmail.Text = row["Email"].ToString();
                textEmail.IsEnabled = false;
                textID.IsEnabled = false;
                AddButton.Content = "Update";
            } else
            {
                MessageBox.Show("Please Select Any Employee From List");
            }
        }

        //Delete record from grid
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (displayData.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)displayData.SelectedItems[0];
                bool status = true;
                    employeesR.Remove(Int32.Parse(row["ID"].ToString()));
                //bool status = employees.Delete(row["ID"].ToString());
                WindowLoaded();
                if (status)
                {
                    MessageBox.Show("Employee " + row["Name"].ToString() + " deleted Successfully");
                }
                ClearAll();
            }
            else
            {
                MessageBox.Show("Please Select Any Employee From List");
            }
        }

        //Exit
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}