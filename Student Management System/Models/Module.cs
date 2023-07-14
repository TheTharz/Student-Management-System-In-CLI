using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public double GradePoint { get; set; }
        public double Credit { get; set; }

        public Module(int moduleid, string name, double credit)
        {
            ModuleId = moduleid;
            Name = name;
            Credit = credit;
            GradePoint= 0;
        }
    }
}
