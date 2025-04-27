using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CollegeManagementSystem
{
    public class Database
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public List<Group> Groups { get; set; } = new List<Group>()
        {
            new Group { GroupId = 1, GroupName = "Group A" },
            new Group { GroupId = 2, GroupName = "Group B" }
        };
    }
}