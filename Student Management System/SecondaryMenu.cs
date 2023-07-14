using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Student_Management_System
{
    public class SecondaryMenu
    {
        public int SubColPos { get; set; }
        public int SubRowPos { get; set;}
        public int SubSelectedItem { get; set; }

        public List<MenuItem> SubMenuItems { get; set; }

        public SecondaryMenu() { 
            SubColPos = 2;
            SubRowPos = 0;
            SubSelectedItem = 0;
            SubMenuItems = new List<MenuItem>
            {
                new MenuItem("Modify User", true),
                new MenuItem("Add Modules", false),
                new MenuItem("Remove Modules", false),
                new MenuItem("Add Grade", false),
                new MenuItem("Back", false)
            };
        }

        public void displaySecondaryMenu(User user)
        {
            Console.BackgroundColor= ConsoleColor.Cyan;
            Console.ForegroundColor= ConsoleColor.Black;

            Console.Clear();
            Console.CursorVisible = false;

            bool runningSecondaryMenu = true;
            bool displaySecondaryMenu = true;

            while(runningSecondaryMenu)
            {
                Console.SetCursorPosition(SubColPos, SubRowPos);

                for(int i=0;i<SubMenuItems.Count;i++)
                {
                    Console.SetCursorPosition(SubColPos, SubRowPos + i);

                    if (SubMenuItems[i].IsSelected)
                    {
                        Console.BackgroundColor= ConsoleColor.Black;
                        Console.ForegroundColor= ConsoleColor.Cyan;
                        if(displaySecondaryMenu)
                        {
                            Console.Write(SubMenuItems[i].Title);
                        }
                    }
                    else
                    {
                        Console.BackgroundColor= ConsoleColor.Cyan;
                        Console.ForegroundColor= ConsoleColor.Black;
                        if(displaySecondaryMenu)
                        {
                            Console.Write(SubMenuItems[i].Title);
                        }
                    }
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    SubMenuItems[SubSelectedItem].IsSelected = false;
                    SubSelectedItem = (SubSelectedItem + 1) % SubMenuItems.Count;

                    SubMenuItems[SubSelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    SubMenuItems[SubSelectedItem].IsSelected = false;
                    SubSelectedItem = SubSelectedItem - 1;

                    if (SubSelectedItem < 0)
                    {
                        SubSelectedItem = SubMenuItems.Count - 1;
                    }

                    SubMenuItems[SubSelectedItem].IsSelected = true;
                }

                if(key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, 0);

                    bool run = true;

                    while(run)
                    {
                        if (SubMenuItems[SubSelectedItem].Title == "Modify User")
                        {
                            //Modify users
                            Console.Clear();
                            Console.CursorVisible = true;
                            StoredData.OneUserDisplay(user);
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("1.Change First Name");
                            Console.WriteLine("2.Change Last Name");
                            Console.WriteLine("3.Change Date of Birth Name");
                            Console.WriteLine("4.Change Address");
                            string response = Console.ReadLine();
                            switch (response)
                            {
                                case "1":
                                    Console.WriteLine("Enter the First Name");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                                    user.FirstName = Console.ReadLine();

                                    Console.WriteLine("The data has been successfully updated");

                                    StoredData.OneUserDisplay(user);
                                    break;
                                case "2":
                                    Console.WriteLine("Enter the Last Name");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                                    user.LastName = Console.ReadLine();
                                    Console.WriteLine("The data has been successfully updated");

                                    StoredData.OneUserDisplay(user);
                                    break;
                                case "3":
                                    Console.WriteLine("Enter the Date of Birth Name");
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    user.DateOfBirth = Console.ReadLine();
                                    Console.WriteLine("The data has been successfully updated");

                                    StoredData.OneUserDisplay(user);
                                    break;
                                case "4":
                                    Console.WriteLine("Enter the Address Name");
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    user.Address = Console.ReadLine();
                                    Console.WriteLine("The data has been successfully updated");

                                    StoredData.OneUserDisplay(user);
                                    break;
                                default:
                                    Console.WriteLine("Invalid Index"!);
                                    break;
                            }


                            Console.CursorVisible = false;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Press any key to insert again");
                            break;

                        }
                        else if (SubMenuItems[SubSelectedItem].Title == "Add Modules")
                        {
                            //Add modules to user
                            Console.Clear();

                            StoredData.OneUserDisplay(user);
                            StoredData.DisplayRegisteredModules(user);
                            StoredData.DisplayModules();

                            Console.ForegroundColor= ConsoleColor.DarkBlue;
                            Console.WriteLine($"\nEnter the Module ID");
                            int ModuleId = Convert.ToInt32(Console.ReadLine());
                            bool isAdded = false;
                            foreach (var module in user.Modules)
                            {
                                if (module.ModuleId == ModuleId)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"User is already registered for {module.Name}");
                                    isAdded = true;
                                    break;
                                }
                            }
                            if(!isAdded) 
                            {
                                StoredData.AddModuleToUser(user.UserId, ModuleId);
                            }

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(1, 21);
                            Console.WriteLine("Press any key to insert again");
                            break;
                        }
                        else if (SubMenuItems[SubSelectedItem].Title == "Remove Modules")
                        {
                            //Remove modules from users
                            Console.Clear();
                            StoredData.DisplayRegisteredModules(user);
                            Console.WriteLine($"\nEnter the modul id to remove modules");
                            int removeId = Convert.ToInt32(Console.ReadLine());
                            bool isDeleted = false;
                            foreach (var module in user.Modules)
                            {
                                if (module.ModuleId == removeId)
                                {
                                    user.Modules.Remove(module);
                                    isDeleted = true;
                                    break;
                                }


                            }
                            Console.Clear();

                            if (isDeleted == false) Console.WriteLine("Module is already removed or you entered wrong ID");
                            StoredData.OneUserDisplay(user);
                            StoredData.DisplayRegisteredModules(user);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 24);
                            Console.WriteLine("Press any key to insert again");

                            break;
                        }
                        else if (SubMenuItems[SubSelectedItem].Title == "Add Grade")
                        {
                            //Add grades for modules
                            Console.Clear();
                            StoredData.DisplayRegisteredModules(user);
                            StoredData.OneUserDisplay(user);
                            Console.WriteLine($"\nEnter the modul id to Add grades");
                            int moduleId = Convert.ToInt32(Console.ReadLine());
                            bool isRegistered = false;
                            foreach (var module in user.Modules)
                            {
                                if (module.ModuleId == moduleId)
                                {
                                    Console.WriteLine("Enter the Grade\n");
                                    Console.WriteLine("A.A\nB.B\nC.C\nF.F");
                                    string grade = Console.ReadLine();
                                    isRegistered = true;
                                    switch (grade)
                                    {
                                        case "A":
                                            module.Grade = "A";
                                            module.GradePoint = 4.0;
                                            Console.WriteLine("Grade A added");
                                            break;
                                        case "B":
                                            module.Grade = "B";
                                            module.GradePoint = 3.0;
                                            Console.WriteLine("Grade B added");
                                            break;
                                        case "C":
                                            module.Grade = "C";
                                            module.GradePoint = 2.0;
                                            Console.WriteLine("Grade C added");
                                            break;
                                        case "F":
                                            module.Grade = "F";
                                            module.GradePoint = 0.0;
                                            Console.WriteLine("Grade E added");
                                            break;
                                        default:
                                            Console.WriteLine("invalid Grade");
                                            break;
                                    }


                                    break;
                                }
                            }
                            if (isRegistered == false) { Console.WriteLine("Please check the grade you entered"); }

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 24);
                            Console.WriteLine("Press any key to insert grades again");

                            break;

                        }
                        else if (SubMenuItems[SubSelectedItem].Title == "Back")
                        {
                            //Back
                            Console.Clear();
                            runningSecondaryMenu = false;
                            run = false;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid");
                            break;
                        }
                    }

                    if(run)
                    {
                        Console.SetCursorPosition(2, 25);
                        Console.WriteLine("Press left arrow to back");

                        var IsBack = Console.ReadKey();
                        Console.Clear();
                        if (IsBack.Key==ConsoleKey.LeftArrow)
                        {
                            run = false;

                        }
                        Console.SetCursorPosition(2, 0);
                    }
                }
            }
        }
    }
}
