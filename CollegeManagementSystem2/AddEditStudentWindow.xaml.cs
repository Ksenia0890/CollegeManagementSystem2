using CollegeManagementSystem;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CollegeManagementSystem2
{
    /// <summary>
    /// Логика взаимодействия для AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        private Student _student = null;

        public Action<AddEditStudentWindow, Student> NewStudetAdded;

        public AddEditStudentWindow(List<CollegeManagementSystem.Group> groups)
        {
            InitializeComponent();
            _student = new Student();
        }
        public AddEditStudentWindow(List<CollegeManagementSystem.Group> groups, Student selectedStudent)
        {
            InitializeComponent();
            _student = selectedStudent;

            txtFullName.Text = _student.FullName;
            dpBirthDate.SelectedDate = _student.BirthDate;
            cmbGender.Text = _student.Gender;
            txtGroupName.Text = _student.GroupName;
            dpEnrollmentDate.SelectedDate = _student.EnrollmentDate;
            txtAddress.Text = _student.Address;
            txtPhone.Text = _student.Phone;
            txtEmail.Text = _student.Email;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _student.FullName = txtFullName.Text;
            _student.BirthDate = (DateTime)dpBirthDate.SelectedDate;
            _student.Gender = cmbGender.Text;
            _student.GroupName = txtGroupName.Text;
            _student.EnrollmentDate = (DateTime)dpEnrollmentDate.SelectedDate;
            _student.Address = txtAddress.Text;
            _student.Phone = txtPhone.Text;
            _student.Email = txtEmail.Text;

            NewStudetAdded?.Invoke(this, _student);

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
