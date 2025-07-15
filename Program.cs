using System;

namespace NewProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentController controller = new StudentController();

            while (true)
            {
                Console.WriteLine("\n====== Student Management System ======");
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. View Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                bool valid = int.TryParse(Console.ReadLine(), out int choice);
                if (!valid) { Console.WriteLine(" Invalid input."); continue; }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Id: ");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name1 = Console.ReadLine();
                        Console.Write("Enter Dept: ");
                        string dept1 = Console.ReadLine();
                        controller.InsertStudent(new Student { Id = id1, Name = name1, Dept = dept1 });
                        break;

                    case 2:
                        Console.Write("Enter Id to View: ");
                        int id2 = int.Parse(Console.ReadLine());
                        controller.GetStudent(id2);
                        break;

                    case 3:
                        Console.Write("Enter Id to Update: ");
                        int id3 = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string name3 = Console.ReadLine();
                        Console.Write("Enter New Dept: ");
                        string dept3 = Console.ReadLine();
                        controller.UpdateStudent(new Student { Id = id3, Name = name3, Dept = dept3 });
                        break;

                    case 4:
                        Console.Write("Enter Id to Delete: ");
                        int id4 = int.Parse(Console.ReadLine());
                        controller.DeleteStudent(id4);
                        break;

                    case 5:
                        Console.WriteLine(" Exiting...");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }
    }
}
