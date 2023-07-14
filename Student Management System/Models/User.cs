using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }

        public List<Module> Modules = new List<Module>();

        public User(int userId, string firstName, string lastName, string dateOfBirth, string address)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public double CalculateGPA(User user) 
        {
            double SumCredit = 0.0;
            double Marks = 0.0;
            foreach (var module in user.Modules)
            {
                SumCredit += module.Credit;
                Marks += (module.GradePoint * module.Credit);
            }
            if(SumCredit!=0)
            {
                double GPA = Marks / SumCredit;
                return GPA;
            }
            return 0.0;
        }
    }
}
