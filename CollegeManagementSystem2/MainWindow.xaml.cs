using CollegeManagementSystem2;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace CollegeManagementSystem
{
    public partial class MainWindow : Window
    {
        private readonly Database _db = new Database();

        public MainWindow()
        {
            InitializeComponent();

            // Load initial data (replace with actual loading from a database)
            _db.Students.Add(new Student { StudentId = 1, FullName = "John Doe", GroupName = "Group A", BirthDate = DateTime.Now.AddYears(-20), EnrollmentDate = DateTime.Now });
            _db.Students.Add(new Student { StudentId = 2, FullName = "Jane Smith", GroupName = "Group B", BirthDate = DateTime.Now.AddYears(-19), EnrollmentDate = DateTime.Now });

            StudentDataGrid.ItemsSource = _db.Students;
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var addEditWindow = new AddEditStudentWindow(_db.Groups);
            addEditWindow.NewStudetAdded += OnNewStudetAdded;
            addEditWindow.ShowDialog();
        }

        private void OnNewStudetAdded(AddEditStudentWindow addEditWindow, Student newStudent)
        {
            newStudent.StudentId = _db.Students.Any() ? _db.Students.Max(s => s.StudentId) + 1 : 1; // Replace with proper ID generation
            _db.Students.Add(newStudent);

            addEditWindow.NewStudetAdded -= OnNewStudetAdded;
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (Student)StudentDataGrid.SelectedItem;

            if (selectedStudent != null)
            {
                var addEditWindow = new AddEditStudentWindow(_db.Groups, selectedStudent);
                addEditWindow.NewStudetAdded += OnStudetEdited;
                addEditWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
            }
        }

        private void OnStudetEdited(AddEditStudentWindow addEditWindow, Student newStudent)
        {
            StudentDataGrid.Items.Refresh(); // Refresh the DataGrid

            addEditWindow.NewStudetAdded -= OnStudetEdited;
        }

        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (Student)StudentDataGrid.SelectedItem;

            if (selectedStudent != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete {selectedStudent.FullName}?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _db.Students.Remove(selectedStudent);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}