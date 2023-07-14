using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public static class StoredData
    {
        public static List<User> users= new List<User>();
        public static int studentId = 4104;

        public static void addUsersForTesting()
        {
            User user1 = new User(4100, "Alex", "Carey","22/09/2000", "Melbourne");
            users.Add(user1);
            addModuleForTesting(user1, 3250);
            addModuleForTesting(user1, 3301);
            addModuleForTesting(user1, 3305);
            addModuleForTesting(user1, 3203);

            User user2 = new User(4101, "Robin", "Davis", "08/09/2001", "London");
            users.Add(user2);
            addModuleForTesting(user2, 3250);
            addModuleForTesting(user2, 3301);
            addModuleForTesting(user2, 3305);
            addModuleForTesting(user2, 3203);

            User user3 = new User(4102, "Kevin", "Thomas", "21/08/2000", "Nirobi");
            users.Add(user3);
            addModuleForTesting(user3, 3250);
            addModuleForTesting(user3, 3301);
            addModuleForTesting(user3, 3305);
            addModuleForTesting(user3, 3203);

            User user4 = new User(4103, "Peter", "Marlon", "11/04/2005", "Dakha");
            users.Add(user4);
            addModuleForTesting(user4, 3250);
            addModuleForTesting(user4, 3301);
            addModuleForTesting(user4, 3305);
            addModuleForTesting(user4, 3203);


        }

        public static void addModuleForTesting(User user,int moduleId)
        {
            AddModuleToUser(user.UserId,moduleId);
        }
        public static void Adduser()
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"New User ID: {studentId} ");

            Console.CursorVisible = true;
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth DD/MM/YEAR: ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            User user = new User(studentId, firstName, lastName, dateOfBirth, address);
            users.Add(user);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;

            studentId++;
        }

        //Display the available modules
        public static void DisplayModules()
        {
           // Console.SetBufferSize(100, 100);
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor= ConsoleColor.Black;
            Console.WriteLine("Available Modules are");
            Console.WriteLine("# 3305 Signal and Systems");
            Console.WriteLine("# 3301 Analog Electronics");
            Console.WriteLine("# 3302 Data Structures and Algorithems");
            Console.WriteLine("# 3203 Measurement");
            Console.WriteLine("# 3251 GUI Prgramming");
            Console.WriteLine("# 3250 Programming  Project");
        }

        //Add modules to registered users
        public static void AddModuleToUser(int UserId, int moduleId)
        {
            foreach(var user in users)
            {
                if(user.UserId== UserId)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    switch(moduleId)
                    {
                        case 3305:
                            Module Signal = new Module(3305, "Signals And Systems", 3);
                            user.Modules.Add(Signal);
                            Console.WriteLine($"User {UserId} has been registered to Module {Signal.Name}");
                            break;

                        case 3301:
                            Module Analog = new Module(3301, "Analog Electronics", 3);
                            user.Modules.Add(Analog);
                            Console.WriteLine($"User {UserId} has been registered to Module {Analog.Name}");
                            break;

                        case 3302:
                            Module Data = new Module(3302, "Data Structures And Algorithms", 3);
                            user.Modules.Add(Data);
                            Console.WriteLine($"User {UserId} has been registered to Module {Data.Name}");
                            break;

                        case 3203:
                            Module Measurement = new Module(3205, "Electrical and Electronic Measurements", 2);
                            user.Modules.Add(Measurement);
                            Console.WriteLine($"User {UserId} has been registered to Module {Measurement.Name}");
                            break;

                        case 3251:
                            Module GUI = new Module(3251, "GUI Programming", 2);
                            user.Modules.Add(GUI);
                            Console.WriteLine($"User {UserId} has been registered to Module {GUI.Name}");
                            break;

                        case 3250:
                            Module Project = new Module(3250, "Programming Project", 2);
                            user.Modules.Add(Project);
                            Console.WriteLine($"User {UserId} has been registered to Module {Project.Name}");
                            break;

                            default:
                            Console.BackgroundColor= ConsoleColor.Red;
                            Console.WriteLine("Please Enter A Valid Module ID!");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                    }
                    break;
                }
            }
        }

        //Display registered modules of a user
        public static void DisplayRegisteredModules(User user)
        {
            Console.SetCursorPosition(75, 0);
            int i = 1;

            Console.WriteLine("----Registered Modules Are----");
            foreach (Module module in user.Modules)
            {
                Console.SetCursorPosition(80, i);
                Console.WriteLine($" |-> {module.ModuleId}  - {module.Name}");
                i++;
            }

            Console.SetCursorPosition(2, 0);
        }


        //Deleting a user
        public static void DeletEUser(User userDelete)
        {
            users.Remove(userDelete);
        }

        //Displaying information of a user
        public static void OneUserDisplay(User user)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-10} {5,-10}", "UserId", "First Name", "Last Name", "Birthday", "Address", "GPA");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-10} {5,-10}", $"{user.UserId}", $"{user.FirstName}", $"{user.LastName}", $"{user.DateOfBirth}", $"{user.Address}", $"{user.CalculateGPA(user)}");
        }

        //Displaying information of all users
        public static void DisplayAllUser()
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            int i = 1;
            //Console.WriteLine("ID\t\tFirst Name\tLast Name\tBirthday\t\tAddress\t\tGPA");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-10} {5,-10}", "UserId", "First Name","Last Name","Birthday","Address","GPA");
            foreach (var user in users)
            {
                Console.SetCursorPosition(0, i+1);
                double g = user.CalculateGPA(user);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                //Console.WriteLine($"{user.UserId}\t{user.FirstName,-15}\t{user.LastName,-15}\t{user.DateOfBirth,-15}\t{user.Address,-50}\t{g,-15}");
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-10} {5,-10}", $"{ user.UserId}", $"{user.FirstName}", $"{user.LastName}", $"{user.DateOfBirth}", $"{user.Address}", $"{user.CalculateGPA(user)}");
                i++;
            }
        }

        public static void IndexUsers()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(50, 0);
            int i = 1;
            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "UserId", "First Name", "Last Name");
            foreach (var user in users)
            {
                Console.SetCursorPosition(50, i);
                i = i + 1;
                Console.WriteLine("{0,-10} {1,-10} {2,-10}", $"{user.UserId}", $"{user.FirstName}", $"{user.LastName}");
            }
            Console.SetCursorPosition(2, 0);
            //Console.ForegroundColor = ConsoleColor.Black;
        }
    }


}
