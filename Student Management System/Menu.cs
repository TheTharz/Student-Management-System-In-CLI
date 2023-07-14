using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Menu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }

        SecondaryMenu SelectUser = new SecondaryMenu();

        public List<MenuItem> MenuItems { get; set; }


        public Menu()
        {
            ColPos = 5;
            RowPos = 3;
            SelectedItem = 0;
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Add User", true),
                new MenuItem("Select User", false),
                new MenuItem("Delete User", false),
                new MenuItem("Display All Users", false),
                new MenuItem("Quit", false)
            };
        }

        //Displaying MainMenu
        public void displayMenu()
        {
            

            StoredData.addUsersForTesting();//for testing purpose
            Console.ForegroundColor= ConsoleColor.Black;
            Console.BackgroundColor= ConsoleColor.Cyan;

            Console.Clear();
            Console.CursorVisible= false;
            bool running = true;
            
            while (running)
            {
                Console.SetCursorPosition(ColPos+10, RowPos-3);
                Console.WriteLine("\t\t\tWelcome To Student Management System");
                Console.SetCursorPosition(ColPos + 10, RowPos - 2);
                Console.WriteLine("\t\t\t------------------------------------\n");
                Console.SetCursorPosition(ColPos, RowPos);

                for(int i=0;i<MenuItems.Count;i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);

                    if (MenuItems[i].IsSelected)
                    {
                        Console.BackgroundColor= ConsoleColor.Black;
                        Console.ForegroundColor= ConsoleColor.Cyan;
                        Console.WriteLine(MenuItems[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Black;
                        Console.BackgroundColor= ConsoleColor.Cyan;
                        Console.WriteLine(MenuItems[i].Title);
                    }
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % MenuItems.Count;

                    MenuItems[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;

                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine($"You selected {MenuItems[SelectedItem].Title}");
                    Console.SetCursorPosition(15, 16);

                    bool stop = false;
                    while (!stop)
                    {
                        if (MenuItems[SelectedItem].Title == "Add User")
                        {

                            //Add user code

                            Console.Clear();
                            StoredData.Adduser();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(2, 25);
                            Console.WriteLine("Press any key to Add another user");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 0);
                            break;
                        }
                        else if (MenuItems[SelectedItem].Title == "Select User")
                        {
                            //Select user code for modify users,add modules,remove modules
                            Console.Clear();
                            StoredData.IndexUsers();
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Enter the User Id");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;

                            int userId = Convert.ToInt32(Console.ReadLine());
                            bool isExist = false;
                            foreach (var user in StoredData.users)
                            {
                                if (user.UserId == userId)
                                {
                                    isExist = true;
                                    SelectUser.displaySecondaryMenu(user);

                                    break;
                                }
                            }
                            if (isExist == false) { Console.WriteLine("invalid user ID"); }


                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(0, 25);
                            //Console.WriteLine("Press any key to select user again");
                           
                            break;

                        }
                        else if (MenuItems[SelectedItem].Title == "Delete User")
                        {

                            //Delete user code
                            Console.Clear();
                            Console.SetCursorPosition(50, 0);
                            StoredData.IndexUsers();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Enter the user Id ");
                            Console.ForegroundColor= ConsoleColor.DarkBlue;
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            bool isDeleted = false;

                            foreach (var user in StoredData.users)
                            {
                                if (user.UserId == deleteId)
                                {
                                    StoredData.OneUserDisplay(user);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("\nDo you want to delete this User");
                                    Console.WriteLine("Press Y for confirmation or press any key for cancel");
                                    var press = Console.ReadKey();
                                    if (press.Key == ConsoleKey.Y)
                                    {
                                        StoredData.DeletEUser(user);
                                        isDeleted = true;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine(" ");
                                        Console.WriteLine($"User {user.UserId} is Removed Successfuly !");
                                    }
                                    else
                                    {
                                        Console.WriteLine(" ");
                                        Console.WriteLine("You have cancelled the deletion");
                                        isDeleted= true;
                                        break;
                                    }

                                    break;
                                }
                            }
                            if (isDeleted == false)
                            {
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(5, 24);
                                Console.WriteLine("Invalid user ID");
                            }
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(5, 25);
                            Console.WriteLine("Press any key to delete again");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(2, 0);
                            break;

                        }
                        else if (MenuItems[SelectedItem].Title == "Display All Users")
                        {
                            //Display all users code
                            Console.Clear();
                            StoredData.DisplayAllUser();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 0);
                            break;
                        }
                        else if (MenuItems[SelectedItem].Title == "Quit")
                        {
                            Console.Clear();
                            Console.SetCursorPosition(50, 8);
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Quiting...");
                            running = false;
                            stop = true;
                            Console.WriteLine("Please wait the window will close soon...");
                            Thread.Sleep(3000);
                            
                        }
                    }
                    if (stop != true)
                    {
                        Console.SetCursorPosition(2, 26);

                        Console.WriteLine("Press left arrow to go back");
                        var go = Console.ReadKey();
                        Console.Clear();
                        if (go.Key == ConsoleKey.LeftArrow)
                        {
                            stop = true;
                        }
                        Console.SetCursorPosition(2, 0);
                    }
                }
            }
        }
    }
}
