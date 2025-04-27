using System;

namespace CollegeManagementSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string GroupName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}