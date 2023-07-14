using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class MenuItem
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }

        public MenuItem(string title, bool isSelected)
        {
            Title = title;
            IsSelected = isSelected;
        }
    }
}
